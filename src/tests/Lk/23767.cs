namespace Application
{
    interface IMenu
    {
        void TurnOn();
    }

    interface IDevice
    {
        void TurnOn();
    }

    abstract class AbstractRemoteController
    {
        private void PressedPowerButton()
        {
            Console.WriteLine("power button pressed");
        }

        public void TurnOn()
        {
            PressedPowerButton();
        }
    }

    class RemoteController : AbstractRemoteController, IMenu, IDevice
    {
        bool batteriesInserted = false;
        bool turnedOn = false;

        void IMenu.TurnOn()
        {
            if (batteriesInserted && turnedOn)
            {
                Console.WriteLine("menu button pressed!!!");
            }
        }

        void IDevice.TurnOn()
        {
            batteriesInserted = true;
            Console.WriteLine("batteries are inserted");
        }

        public new void TurnOn()
        {
            if (batteriesInserted)
            {
                base.TurnOn();
                Console.WriteLine("wait...");
                Thread.Sleep(1000);
                turnedOn = !turnedOn;
                Console.WriteLine("turned on");
                 
            }
        }

        public void PressMenu()
        {
            ((IMenu)this).TurnOn();
        }

        public void InsertBatteries()
        {
            ((IDevice)this).TurnOn();
        }
    }

    class Task2
    {
        static int Main()
        {
            var remoteController = new RemoteController();
            remoteController.PressMenu();
            Thread.Sleep(200);

            remoteController.TurnOn();
            Thread.Sleep(200);
            remoteController.PressMenu();
            Thread.Sleep(200);

            remoteController.InsertBatteries();
            Thread.Sleep(200);
            remoteController.TurnOn();
            Thread.Sleep(200);
            remoteController.PressMenu();
            Thread.Sleep(200);

            remoteController.TurnOn();
            Thread.Sleep(200);
            remoteController.PressMenu();
            Thread.Sleep(200);
            return 0;
        }
    }
}
