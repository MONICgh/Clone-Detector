using SleepingHairdresser;

var hairdresser = new Hairdresser(3);

hairdresser.AddClient(new Client("1"));
hairdresser.AddClient(new Client("2"));
hairdresser.AddClient(new Client("3"));
hairdresser.AddClient(new Client("4"));
hairdresser.AddClient(new Client("5"));

Thread.Sleep(5000);

hairdresser.AddClient(new Client("Neo"));

hairdresser.Stop();