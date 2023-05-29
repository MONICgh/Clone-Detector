namespace Application
{
    enum HourseBreed
    {
        Arabian,
        EnglishThoroughbred,
        AkhalTeke,
        AngloNorman,
        Percheron,
        Belgian,
        Azerbaijani,
        Karabakh,
        Deliboz,
        CubanPacers,
        Other
    }

    enum HorseAppointment
    {
        Riding,
        Horse_harness,
        Light_harness,
        Heavy_draft,
        Horse_pack
    }

    enum HorseOrigin
    {
        Cultural,
        Transitional,
        Aboriginal
    }

    class Hourse
    {
        public float Weight;
        public float Height;
        public bool Savvy;
        public int Age;
        public HourseBreed? Breed = null;
        public HorseAppointment? Appointment = null;
        public HorseOrigin? Origin = null;

        public Hourse() {}

        public Hourse(float weight, float height, bool savvy = false, int age = 0,
            HourseBreed? breed = null, HorseAppointment? appointment = null, HorseOrigin? origin = null)
        {
            this.Weight = weight;
            this.Height = height;
            this.Savvy = savvy;
            this.Age = age;
            this.Breed = breed;
            this.Appointment = appointment;
            this.Origin = origin;
        }

        private static HourseBreed BreedFromBrand(CarBrand brand)
        {
            switch (brand)
            {
                case CarBrand.Nissan:
                    return HourseBreed.Arabian;
                case CarBrand.Porsche:
                    return HourseBreed.EnglishThoroughbred;
                case CarBrand.Audi:
                    return HourseBreed.AkhalTeke;
                case CarBrand.Hyundai:
                    return HourseBreed.AngloNorman;
                case CarBrand.Ford:
                    return HourseBreed.Percheron;
                case CarBrand.Volkswagen:
                    return HourseBreed.Belgian;
                case CarBrand.Honda:
                    return HourseBreed.Azerbaijani;
                case CarBrand.BMW:
                    return HourseBreed.Karabakh;
                case CarBrand.MercedesBenz:
                    return HourseBreed.Deliboz;
                case CarBrand.Toyota:
                    return HourseBreed.CubanPacers;
                default:
                    return HourseBreed.Other;
            }
        }

        private static CarBrand BrandFromBreed(HourseBreed? breed)
        {
            switch (breed)
            {
                case HourseBreed.Arabian:
                    return CarBrand.Nissan;
                case HourseBreed.EnglishThoroughbred:
                    return CarBrand.Porsche;
                case HourseBreed.AkhalTeke:
                    return CarBrand.Audi;
                case HourseBreed.AngloNorman:
                    return CarBrand.Hyundai;
                case HourseBreed.Percheron:
                    return CarBrand.Ford;
                case HourseBreed.Belgian:
                    return CarBrand.Volkswagen;
                case HourseBreed.Azerbaijani:
                    return CarBrand.Honda;
                case HourseBreed.Karabakh:
                    return CarBrand.BMW;
                case HourseBreed.Deliboz:
                    return CarBrand.MercedesBenz;
                case HourseBreed.CubanPacers:
                    return CarBrand.Toyota;
                default:
                    return CarBrand.Other;
            }
        }

        public static implicit operator Hourse(Car x)
        {
            return new Hourse
            {
                Weight = x.Weight,
                Height = x.Height,
                Savvy = x.StuddedRubberTires,
                Age = x.Lifetime,
                Breed = BreedFromBrand(x.Brand)
            };
        }

        public static explicit operator Car(Hourse x)
        {
            return new Car
            {
                Weight = x.Weight,
                Height = x.Height,
                StuddedRubberTires = x.Savvy,
                Lifetime = x.Age,
                Brand = BrandFromBreed(x.Breed)
            };
        }

        public override string ToString()
        {
            return string.Format("Hourse(Weight={0}, Height={1}, Savvy={2}, Age={3}, Breed={4}, " +
                "Appointment={5}, Origin={6})", Weight, Height, Savvy, Age, Breed, Appointment, Origin);
        }

        public static bool operator <(Hourse h1, Hourse h2)
        {
            if (h1.Savvy == h2.Savvy)
                return (h1.Weight * h1.Height - h1.Age) - (h2.Weight * h2.Height - h1.Age) < 0;
            else
                return h1.Savvy;
        }

        public static bool operator >(Hourse h1, Hourse h2)
        {
            return !(h1 < h2);
        }
    }

    enum CarBrand
    {
        Nissan,
        Porsche,
        Audi,
        Hyundai,
        Ford,
        Volkswagen,
        Honda,
        BMW,
        MercedesBenz,
        Toyota,
        Other
    }

    class Car
    {
        public float Weight;
        public float Height;
        public bool StuddedRubberTires;
        public int Lifetime;
        public CarBrand Brand = CarBrand.Other;
        public int? SerialNumber = null;

        public Car() { }

        public Car(float weight, float height, bool studdedRubberTires = false, int lifetime = 0,
            CarBrand brand = CarBrand.Other, int? serialNumber = null)
        {
            this.Weight = weight;
            this.Height = height;
            this.StuddedRubberTires = studdedRubberTires;
            this.Lifetime = lifetime;
            this.Brand = brand;
            this.SerialNumber = serialNumber;
        }

        public override string ToString()
        {
            return string.Format("Car(Weight={0}, Height={1}, StuddedRubberTires={2}, Lifetime={3}, Brand={4}, " +
                "SerialNumber={5})", Weight, Height, StuddedRubberTires, Lifetime, Brand, SerialNumber);
        }

        public static bool operator <(Car h1, Car h2)
        {
            if (h1.StuddedRubberTires == h2.StuddedRubberTires)
                return (h1.Weight * h1.Height - h1.Lifetime) - (h2.Weight * h2.Height - h1.Lifetime) < 0;
            else
                return h1.StuddedRubberTires;
        }

        public static bool operator >(Car h1, Car h2)
        {
            return !(h1 < h2);
        }
    }

    class Task1
    {
        static int Main()
        {
            var car = new Car(weight: 2_000, height: 1, lifetime: 5, brand: CarBrand.Porsche);
            Console.WriteLine(car);
            Hourse hourseCar = car;
            Console.WriteLine(hourseCar);
            var hourseCar2 = (Hourse)car;
            Console.WriteLine(hourseCar2);
            Car carHourseCar = (Car)hourseCar;
            Console.WriteLine(carHourseCar);
            Console.WriteLine();

            var hourse = new Hourse(weight: 300, height: 1.6f, savvy: false, age: 2, breed: HourseBreed.AkhalTeke,
                appointment: HorseAppointment.Heavy_draft, origin: HorseOrigin.Aboriginal);
            Console.WriteLine(hourse);
            Car carHourse = (Car)hourse;
            Console.WriteLine(carHourse);
            Hourse hourseCarHourse = carHourse;
            Console.WriteLine(hourseCarHourse);
            Console.WriteLine();

            var miniCar = new Car(weight: 0.5f, height: 0.1f, studdedRubberTires: true, lifetime: 1, brand: CarBrand.BMW);
            var bigCar = new Car(weight: 5_000, height: 100, lifetime: 100, brand: CarBrand.Porsche);
            Console.WriteLine("{0} < {1}: {2}", "car", "miniCar", car < miniCar);
            Console.WriteLine("{0} < {1}: {2}", "car", "bigCar", car < bigCar);
            Console.WriteLine("{0} < {1}: {2}", "bigCar", "miniCar", bigCar < miniCar);

            return 0;
        }
    }
}
