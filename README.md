# Тестовое задание по выводу пассажиров на рейс

### Описание:

В рамках задания был использованы принципы инверсии зависимости и DI-контейнер. Работа с данными представлена в репозиториях. Бизнес-логика вынесена в сервисы. Все взаимосвязи между классами передаются через инъекции интерфейсов через конструкторы. Инициализация и экземпляры хранятся в DI-контейнере в App.xaml

Добавила Material Design для визуала :)

### Примечания:
- Можно заметить, что хост публичный и статичный. Сделано для того, чтобы из любой точки приложения можно было вызывать хост для вызова других окон например, если окон станет больше

- MainWindow я решила сделать Singleton, так как сейчас распространена фреймовая структура - есть главное окно, которое является хранилищем для большого количества фреймов. Закрывается главное окно - закрывается приложение. Все последующие окна - модальные или диалоговые, их закрытие ни на что не влияет. А вот основное окно должно быть одним, поэтому я сделала его Singleton

- Для расширения DI-контейнера я также попробовала заменить Майкрософтовский контейнер на SimpleInjector (также и для ускорения работы), но встретилась с ошибками о конфликте жизненных циклов между Singleton и Transient, и решила оставить тот вариант, который есть сейчас. Наработки App.xaml.cs также прилагаю

```
public partial class App : Application
{
    public static Container? Container { get; private set; }

    public App()
    {
        Container = new Container();
        Container.Register<ILoadSaveService, PassengerService>();
        Container.Register<IDataRepository, JsonRepository>();


        //именно эта регистрация вызывала ошибку, но если я убираю Singleton, то при закрытии окна  оно не закрывает приложение. не хотелось задерживать тестовое задание, так что я вернула все в первоначальному виду
        Container.Register<MainWindow>(Lifestyle.Singleton);

        Container.Verify();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e); 
        this.MainWindow = Container!.GetInstance<MainWindow>();
        this.MainWindow.Show();
    }

    protected override async void OnExit(ExitEventArgs e){
        await Container!.DisposeAsync();
        base.OnExit(e);
    }
}
```