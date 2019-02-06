namespace std_3_st2
{

    public class MainApp {
        public static void Main() {
            Car car1 = new Car();
            car1.Id = 1;
            car1.Model="Volkswagen Golf";
            car1.MilesTraveled=160000;
            car1.Owner = "Бат Алексей от Перник";
            car1.RegistrationNumber = "BG1234ПЕ";

            Car car2 = new Car();
            car2.Id = 2;
            car2.Model="BMW E36";
            car2.MilesTraveled=340000;
            car2.Owner = "Крум \"Мънито\" Дропов";
            car2.RegistrationNumber = "BG1234СФ";

            Repository.GetInstance().save(car1.Id, car1);
            Repository.GetInstance().save(car2.Id, car2);

            PrintCar(Repository.GetInstance().FindById(car1.Id));
            PrintCar(Repository.GetInstance().FindById(car2.Id));
        }

        public static void PrintCar(Car car) {
            System.Console.WriteLine("------------");
            System.Console.WriteLine("Идентификатор: {0}", car.Id);
            System.Console.WriteLine("Модел: {0}", car.Model);
            System.Console.WriteLine("Изпътувани Мили: {0}", car.MilesTraveled);
            System.Console.WriteLine("Собственик: {0}", car.Owner);
            System.Console.WriteLine("Регистрация: {0}", car.RegistrationNumber);
        }
    }

    public class Car {
        public long Id {get;set}

        public string Model {get;set;}

        public int MilesTraveled{get;set;}

        public string Owner {get;set;}

        public string RegistrationNumber{get;set;}
    }


    public class Repository {

        private static Repository _instance;

        private Dictionary<long,object> repository = new Dictionary<long, object>();

        public void Save(long id, object obj) {
            repository.Add(id, obj);
        }

        public object FindById(long id) {
            return repository[id];
        }

        public void Update(long id, object obj) {
            repository[id] = obj;
        }

        public void Delete(long id) {
            repository.Remove(id);
        }

        public Repository GetInstance() {
            if (_instance == null) {
                _instance = new Repository();
            }

            return _instance;
        }
    }
}