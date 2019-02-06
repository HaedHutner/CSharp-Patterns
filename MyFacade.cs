namespace std_3_st2.Facade
{
    public class FacadeMainApp {

        public static void Main() {
            CarFacade facade = new CarFacade();

            facade.createAndStoreCar(
                13,
                "Москвич, много запазен",
                420000,
                "Дядо Петър",
                "БГ1243СТ"
            );

            facade.printCarFromId(13);
        }

    }

    public class CarFacade {
        public void createAndStoreCar(long id, string model, int miles, string owner, string registrationNumber) {
            Car car = new Car ();
            car.Id = id;
            car.Model = model;
            car.MilesTraveled = miles;
            car.Owner = owner;
            car.RegistrationNumber = registrationNumber;

            Repository.GetInstance().Save(car);
        }

        public printCarFromId(long id) {
            Car car = Repository.GetInstance().FindById(id);

            System.Console.WriteLine ("------------");
            System.Console.WriteLine ("Идентификатор: {0}", car.Id);
            System.Console.WriteLine ("Модел: {0}", car.Model);
            System.Console.WriteLine ("Изпътувани Мили: {0}", car.MilesTraveled);
            System.Console.WriteLine ("Собственик: {0}", car.Owner);
            System.Console.WriteLine ("Регистрация: {0}", car.RegistrationNumber);
        }
    }

    public class Repository {
        private static Repository _instance;

        private Repository() {}

        private Dictionary<long, object> repository = new Dictionary<long, object> ();

        public void Save (long id, object obj) {
            repository.Add (id, obj);
        }

        public object FindById (long id) {
            return repository[id];
        }

        public void Update (long id, object obj) {
            repository[id] = obj;
        }

        public void Delete (long id) {
            repository.Remove (id);
        }

        public static Repository GetInstance () {
            if (_instance == null) {
                _instance = new Repository ();
            }

            return _instance;
        }
    }

    public class Car {
        public long Id { get; set; }

        public string Model { get; set; }

        public int MilesTraveled { get; set; }

        public string Owner { get; set; }

        public string RegistrationNumber { get; set; }
    }
}