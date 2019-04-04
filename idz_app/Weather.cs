using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idz_app
{
    public enum OvercastStatus
    { 
        clear,
        overcast,
        cloudy, 
        nothing
    };
    public enum WindStatus
    {
        North,
        East,
        West,
        South,
        nothing
    };
    public enum PrecipitationStatus
    {
        rain, 
        snow, 
        fog, 
        dew, 
        hail,
        nothing
    };

    public abstract class Time 
    {
        private int _hours;
        private int _minutes;

        public Time()
        {
            _hours = 0;
            _minutes = 0;
        }

        public int hours
        {
            get { return _hours; }
            set { _hours = value; }
        }
        public int minutes
        {
            get { return _minutes; }
            set { _minutes = value; }
        }
        public Time(int hours, int minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
        }
 
    }

    public abstract class Data : Time
    {
        private int _day;
        private int _month;
        private int _year;

        public Data()
        {
            _day = 1;
            _month = 1;
            _year = 2018;
        }

        public int day
        {
            get { return _day; }
            set { _day = value; }
        }
        public int month
        {
            get { return _month; }
            set { _month = value; }
        }
        public int year
        {
            get { return _year; }
            set { _year = value; }
        }

        public Data(int day, int month, int year,
               int hours, int minutes)
        {
            this.day = day;
            this.month = month;
            this.year = year;
            this.hours = hours;
            this.minutes = minutes;
        }
    }

    public abstract class Properties : Data
    {
        private int _MinTemp;
        private int _MaxTemp;
        private int _Pressure;

        public Properties()
        {
            _MinTemp = 0;
            _MaxTemp = 0;
            _Pressure = 0;
        }

        public int MinTemp
        {
            get { return _MinTemp; }
            set { _MinTemp = value; }
        }
        public int MaxTemp
        {
            get { return _MaxTemp; }
            set { _MaxTemp = value; }
        }
        public int Pressure
        {
            get { return _Pressure; }
            set { _Pressure = value; }
        }

        public Properties(int MinTemp, int MaxTemp, int Pressure,
            int day, int month, int year, 
            int hours, int minutes)
        {
            this.MinTemp = MinTemp;
            this.MaxTemp = MaxTemp;
            this.Pressure = Pressure;
            this.day = day;
            this.year = year;
            this.hours = hours;
            this.minutes = minutes;
        }
    }

    public class Weather : Properties
    {
        private OvercastStatus _overcast;
        private WindStatus _wind;
        private PrecipitationStatus _precipitation;

        public OvercastStatus status_of_overcast
        {
            get { return _overcast; }
            set { _overcast = value; }
        }
        public WindStatus status_of_wind
        {
            get { return _wind; }
            set { _wind = value; }
        }
        public PrecipitationStatus status_of_precipitation
        {
            get { return _precipitation; }
            set { _precipitation = value; }
        }

        public Weather()
        {
        }

        public Weather(int MinTemp, int MaxTemp, int Pressure,
               int day, int month, int year,
               int hours, int minutes,
               OvercastStatus overcast, WindStatus wind, PrecipitationStatus precipitation)
        {
            this.MinTemp = MinTemp;
            this.MaxTemp = MaxTemp;
            this.Pressure = Pressure;
            this.day = day;
            if (day < 1 || day > 31)
            {
                Console.WriteLine("Input day once more please");
            }
            this.month = month;
            if (month < 1 || month > 12)
            {
                Console.WriteLine("Input month once more please");
            }
            this.year = year;
            if (year < 2000 || year > 2100)
            {
                Console.WriteLine("Input year once more please");
            }
            this.hours = hours;
            if (hours < 1 || hours > 24)
            {
                Console.WriteLine("Input hours once more please");
            }
            this.minutes = minutes;
            if (minutes < 1 || minutes > 60)
            {
                Console.WriteLine("Input minutes once more please");
            }
            this.status_of_overcast = overcast;
            this.status_of_wind = wind;
            this.status_of_precipitation = precipitation;
        }

    }

    public class Raspisanie : Weather
    {
        
        public List<Weather> Weathers = new List<Weather>();
        public Raspisanie()
        {
        }

        public void ShowWeather()
        {
            Console.WriteLine("Weathers for {0} days", Weathers.Count);
            Console.WriteLine("==========================");

            foreach (var Day in Weathers)
            {
                Console.Write("MinTemp:\t{0}\n", Day.MinTemp);
                Console.Write("MaxTemp:\t{0}\n", Day.MaxTemp);
                Console.Write("Pressure:\t{0}\n", Day.Pressure);
                Console.Write("day:\t{0}\n", Day.day);
                Console.Write("month:\t{0}\n", Day.month);
                Console.Write("year:\t{0}\n", Day.year);
                Console.Write("hours:\t{0}\n", Day.hours);
                Console.Write("minutes:\t{0}\n", Day.minutes);
                Console.Write("status_of_overcast:\t{0}\n", Day.status_of_overcast);
                Console.Write("status_of_wind:\t{0}\n", Day.status_of_wind);
                Console.Write("status_of_precipitation:\t{0}\n", Day.status_of_precipitation);
                Console.WriteLine("---------------------------");
            }
        }

        public void InputOneDay()
        {
            int TheMinTemp, TheMaxTemp, ThePressure,
            TheDay, TheMonth, TheYear,
            TheHours, TheMinute;
            OvercastStatus TheStatus_of_overcast;
            WindStatus TheStatus_of_wind;
            PrecipitationStatus TheStatus_of_precipitation;

        NN:

            Console.Write("MinTemp: ");
            string strdatkey_min = Console.ReadLine();
            TheMinTemp = Convert.ToInt32(strdatkey_min);
            Console.Write("MaxTemp: ");
            string strdatkey_max = Console.ReadLine();
            TheMaxTemp = Convert.ToInt32(strdatkey_max);
            Console.Write("Pressure: ");
            string strdatkey_pres = Console.ReadLine();
            ThePressure = Convert.ToInt32(strdatkey_pres);

            do
            {
                Console.Write("day: ");
                string strdatkey = Console.ReadLine();
                TheDay = Convert.ToInt32(strdatkey);
            } while (TheDay < 1 || TheDay > 31);

            do
            {
                Console.Write("month: ");
                string strdatkey = Console.ReadLine();
                TheMonth = Convert.ToInt32(strdatkey);
            } while (TheMonth < 1 || TheMonth > 12);

            do
            {
                Console.Write("year: " );
                string strdatkey = Console.ReadLine();
                TheYear = Convert.ToInt32(strdatkey);
            } while (TheYear < 2000 || TheYear > 2100);

            do
            {
                Console.Write("hours: ");
                string strdatkey = Console.ReadLine();
                TheHours = Convert.ToInt32(strdatkey);
            } while (TheHours < 1 || TheHours > 24);

            do           
            {
                Console.Write("minutes: ");
                string strdatkey = Console.ReadLine();
                TheMinute = Convert.ToInt32(strdatkey);
            }
            while (TheMinute < 1 || TheMinute > 60);


            Console.WriteLine("---------------------------");
            Console.WriteLine("1.clear");
            Console.WriteLine("2.cloudy");
            Console.WriteLine("3.nothing");
            Console.WriteLine("4.overcast");
            Console.Write("status_of_overcast: ");
            int CinTheStatus_of_overcast = Convert.ToInt32(Console.ReadLine());
            switch (CinTheStatus_of_overcast)
            {
                case 1:
                    TheStatus_of_overcast = OvercastStatus.clear;
                    break;
                case 2:
                    TheStatus_of_overcast = OvercastStatus.cloudy;
                    break;
                case 3:
                    TheStatus_of_overcast = OvercastStatus.nothing;
                    break;
                case 4:
                    TheStatus_of_overcast = OvercastStatus.overcast;
                    break;
                default:
                    TheStatus_of_overcast = OvercastStatus.nothing;
                    break;
            }
            Console.WriteLine("---------------------------");
            Console.WriteLine("1.East");
            Console.WriteLine("2.North");
            Console.WriteLine("3.nothing");
            Console.WriteLine("4.South");
            Console.WriteLine("5.West");
            Console.Write("status_of_wind: ");
            int CinTheStatus_of_wind = Convert.ToInt32(Console.ReadLine());
            switch (CinTheStatus_of_wind)
            {
                case 1:
                    TheStatus_of_wind = WindStatus.East;
                    break;
                case 2:
                    TheStatus_of_wind = WindStatus.North;
                    break;
                case 3:
                    TheStatus_of_wind = WindStatus.nothing;
                    break;
                case 4:
                    TheStatus_of_wind = WindStatus.South;
                    break;
                case 5:
                    TheStatus_of_wind = WindStatus.West;
                    break;
                default:
                    TheStatus_of_wind = WindStatus.nothing;
                    break;
            }
            Console.WriteLine("---------------------------");
            Console.WriteLine("1.dew");
            Console.WriteLine("2.fog");
            Console.WriteLine("3.hail");
            Console.WriteLine("4.nothing");
            Console.WriteLine("5.rain");
            Console.WriteLine("6.snow");
            Console.Write("status_of_precipitation: ");
            int CinTheStatus_of_precipitation = Convert.ToInt32(Console.ReadLine());
            switch (CinTheStatus_of_precipitation)
            {
                case 1:
                    TheStatus_of_precipitation = PrecipitationStatus.dew;
                    break;
                case 2:
                    TheStatus_of_precipitation = PrecipitationStatus.fog;
                    break;
                case 3:
                    TheStatus_of_precipitation = PrecipitationStatus.hail;
                    break;
                case 4:
                    TheStatus_of_precipitation = PrecipitationStatus.nothing;
                    break;
                case 5:
                    TheStatus_of_precipitation = PrecipitationStatus.rain;
                    break;
                case 6:
                    TheStatus_of_precipitation = PrecipitationStatus.snow;
                    break;
                default:
                    TheStatus_of_precipitation = PrecipitationStatus.nothing;
                    break;
            }

            Weathers.Add(new Weather(TheMinTemp, TheMaxTemp, ThePressure,
            TheDay, TheMonth, TheYear,
            TheHours, TheMinute,
            TheStatus_of_overcast,
            TheStatus_of_wind,
            TheStatus_of_precipitation));
            Console.WriteLine("Want to add another one day?");
            Console.WriteLine("1.Yes");
            Console.WriteLine("2.No");
            Console.Write("Your choise: ");
            int Choise = Convert.ToInt32(Console.ReadLine());
            if (Choise == 1)
            {
                goto NN;
            }
        }

        public void ShowWeather(int k)
        {
            Console.WriteLine("Weather for {0} day", k);
            Console.WriteLine("==========================");

            foreach (var Day in Weathers)
            {
                if (Day.day == k)
                {
                    Console.Write("MinTemp:\t{0}\n", Day.MinTemp);
                    Console.Write("MaxTemp:\t{0}\n", Day.MaxTemp);
                    Console.Write("Pressure:\t{0}\n", Day.Pressure);
                    Console.Write("day:\t{0}\n", Day.day);
                    Console.Write("month:\t{0}\n", Day.month);
                    Console.Write("year:\t{0}\n", Day.year);
                    Console.Write("hours:\t{0}\n", Day.hours);
                    Console.Write("minutes:\t{0}\n", Day.minutes);
                    Console.Write("status_of_overcast:\t{0}\n", Day.status_of_overcast);
                    Console.Write("status_of_wind:\t{0}\n", Day.status_of_wind);
                    Console.Write("status_of_precipitation:\t{0}\n", Day.status_of_precipitation);
                    Console.WriteLine("---------------------------");
                    AvarageTemperatureForDay(Day.MinTemp, Day.MaxTemp);
                    Console.WriteLine("---------------------------");
                }
            }
        }

        private void AvarageTemperatureForDay(int MinTemp, int MaxTemp)
        {
            int AvarTemp = (MinTemp + MaxTemp) / 2;
            Console.WriteLine("AvarageTemperatureForDay: {0}", AvarTemp);
        }

        public void StatusForWeek()
        {
            AvarageOfRainyDays();
            AvarageOfSunnyDays();
            MinTempOfWeek();
            MaxTempOfWeek();
        }

        private void AvarageOfSunnyDays()
        {
            int SunDaysAvar = 0;
            foreach (var Day in Weathers)
            {
                if (Day.status_of_overcast == OvercastStatus.clear || Day.status_of_overcast == OvercastStatus.nothing)
                {
                    ++SunDaysAvar;
                }
            }
                Console.WriteLine("AvarageOfSunnyDays: {0}", SunDaysAvar);            
        }

        private void AvarageOfRainyDays()
        {
            int RainDaysAvar = 0;
            foreach (var Day in Weathers)
            {
                if (Day.status_of_precipitation == PrecipitationStatus.rain || Day.status_of_precipitation == PrecipitationStatus.fog)
                {
                    ++RainDaysAvar;
                }
            }
            Console.WriteLine("AvarageOfRainyDays: {0}", RainDaysAvar);
        }

        private void MinTempOfWeek()
        {
            int MinTempOfWeek = 100;
            foreach (var Day in Weathers)
            {
                if (Day.MinTemp < MinTempOfWeek)
                {
                    MinTempOfWeek = Day.MinTemp;
                }
            }
            Console.WriteLine("MinTempOfWeek: {0}", MinTempOfWeek);
        }

        private void MaxTempOfWeek()
        {
            int MaxTempOfWeek = -100;
            foreach (var Day in Weathers)
            {
                if (Day.MaxTemp > MaxTempOfWeek)
                {
                    MaxTempOfWeek = Day.MaxTemp;
                }
            }
            Console.WriteLine("MaxTempOfWeek: {0}", MaxTempOfWeek);
        }

        public void DelOneDay(int k)
        {
            string strdatkey;
            int datkey = 0;
            if (k >= Weathers.Count)
            {
                do
                {
                    Console.Write("Input number of day you want delete: ");
                    strdatkey = Console.ReadLine();
                    datkey = Convert.ToInt32(strdatkey);
                    k = datkey;
                }
                while (datkey >= Weathers.Count);
            }
            Weathers.RemoveAt(k);
        }

        public void DelAll()
        {
            Weathers.Clear();
        }

        public void Set_text_in_file(string fileName)
        {
            StreamWriter sw = new StreamWriter(fileName);
            foreach(var Day in Weathers)
            {
                sw.Write("MinTemp: ");
                sw.WriteLine(Day.MinTemp);      
                sw.Write("MaxTemp: ");
                sw.WriteLine(Day.MaxTemp);
                sw.Write("Pressure: ");
                sw.WriteLine(Day.Pressure);
                sw.Write("day: ");
                sw.WriteLine(Day.day);
                sw.Write("month: ");
                sw.WriteLine(Day.month);
                sw.Write("year: ");
                sw.WriteLine(Day.year);
                sw.Write("hours: ");
                sw.WriteLine(Day.hours);
                sw.Write("minutes: ");
                sw.WriteLine(Day.minutes);
                sw.Write("status of overcast: ");
                sw.WriteLine(Day.status_of_overcast);
                sw.Write("status of wind: ");
                sw.WriteLine(Day.status_of_wind);
                sw.Write("status of precipitation: ");
                sw.WriteLine(Day.status_of_precipitation);
                sw.WriteLine("");
            }
        }

        public void Get_ruk_polz(string fileName)
        {
            string[] readText = File.ReadAllLines(fileName);
            foreach (string s in readText)
            {
                Console.WriteLine(s);
            }
        }

        public void Get_text_from_file(string fileName)
        {
            int TheMinTemp = 0, TheMaxTemp = 0, ThePressure = 0,
            TheDay = 0, TheMonth = 0, TheYear = 0,
            TheHours = 0, TheMinute = 0;
            OvercastStatus TheStatus_of_overcast = OvercastStatus.nothing;
            WindStatus TheStatus_of_wind = WindStatus.nothing;
            PrecipitationStatus TheStatus_of_precipitation = PrecipitationStatus.nothing;

            FileStream file = new FileStream(fileName, FileMode.Open);
            StreamReader readFile = new StreamReader(file);
            while (!readFile.EndOfStream)
            {
                string newString = readFile.ReadLine();
                string[] fromFile = newString.Split(' ');
                for (int i = 0; i < fromFile.Length; i++)
                {
                    if (i == 0)
                        TheMinTemp = Convert.ToInt32(fromFile[i]);
                    if (i == 1)
                        TheMaxTemp = Convert.ToInt32(fromFile[i]);
                    if (i == 2)
                        ThePressure = Convert.ToInt32(fromFile[i]);
                    if (i == 3)
                        TheDay = Convert.ToInt32(fromFile[i]);
                    if (i == 4)
                        TheMonth = Convert.ToInt32(fromFile[i]);
                    if (i == 5)
                        TheYear = Convert.ToInt32(fromFile[i]);
                    if (i == 6)
                        TheHours = Convert.ToInt32(fromFile[i]);
                    if (i == 7)
                        TheMinute = Convert.ToInt32(fromFile[i]);
                    if (i == 8)
                    {
                         switch (Convert.ToInt32(fromFile[i]))
                         {
                                case 1:
                                    TheStatus_of_overcast = OvercastStatus.clear;
                                    break;
                                case 2:
                                    TheStatus_of_overcast = OvercastStatus.cloudy;
                                    break;
                                case 3:
                                    TheStatus_of_overcast = OvercastStatus.nothing;
                                    break;
                                case 4:
                                    TheStatus_of_overcast = OvercastStatus.overcast;
                                    break;
                                default:
                                    TheStatus_of_overcast = OvercastStatus.nothing;
                                    break;
                         }
                    }
                    if (i == 9)
                    {
                        switch (Convert.ToInt32(fromFile[i]))
                        {
                            case 1:
                                TheStatus_of_wind = WindStatus.East;
                                break;
                            case 2:
                                TheStatus_of_wind = WindStatus.North;
                                break;
                            case 3:
                                TheStatus_of_wind = WindStatus.nothing;
                                break;
                            case 4:
                                TheStatus_of_wind = WindStatus.South;
                                break;
                            case 5:
                                TheStatus_of_wind = WindStatus.West;
                                break;
                            default:
                                TheStatus_of_wind = WindStatus.nothing;
                                break;
                        }
                    }
                    if (i == 10)
                    {
                        switch (Convert.ToInt32(fromFile[i]))
                        {
                            case 1:
                                TheStatus_of_precipitation = PrecipitationStatus.dew;
                                break;
                            case 2:
                                TheStatus_of_precipitation = PrecipitationStatus.fog;
                                break;
                            case 3:
                                TheStatus_of_precipitation = PrecipitationStatus.hail;
                                break;
                            case 4:
                                TheStatus_of_precipitation = PrecipitationStatus.nothing;
                                break;
                            case 5:
                                TheStatus_of_precipitation = PrecipitationStatus.rain;
                                break;
                            case 6:
                                TheStatus_of_precipitation = PrecipitationStatus.snow;
                                break;
                            default:
                                TheStatus_of_precipitation = PrecipitationStatus.nothing;
                                break;
                        }
                    }
                }
                Weathers.Add(new Weather(TheMinTemp, TheMaxTemp, ThePressure,
                    TheDay, TheMonth, TheYear,
                    TheHours, TheMinute,
                    TheStatus_of_overcast,
                    TheStatus_of_wind,
                    TheStatus_of_precipitation));
            }
            readFile.Close();  
        }
    }
}
