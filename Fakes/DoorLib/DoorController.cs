using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace DoorLib
{
    interface IDoorController
    {
        void openDoor();
        void CloseDoor();
        void ValidateRequest(int id);
        void alarm();
        void breached();
        void DoorClosed();
        void DoorOpen();
    }
    public class DoorController : IDoorController
    {

        private List<int> idokList;
        private bool isBreached = false;
        private bool Validation = false;
        private bool doorClosed = false;

        public DoorController()
        {
           DoorClosed();
            idokList.Add(1); //1 er ok
        }


        public void openDoor()
        {
            if (Validation)
            {
                Console.WriteLine("door opening");
                DoorOpen();
            }
            alarm();

        }

        public void CloseDoor()
        {
            Console.WriteLine("door closing");
            DoorClosed();
        }

        public void ValidateRequest(int id)
        {
            if(doorClosed)
            {
                foreach (var VARIABLE in idokList)
                {
                    if (VARIABLE == id) //its ok!
                    {
                        Validation = true;
                        openDoor();
                    }

                    DoorClosed(); //no ok
                }
            }

        }

        public void alarm()
        {
            Console.WriteLine("Alarm!");
            breached();
        }

        public void breached()
        {
            while (true)
            {
                Console.WriteLine("Breached!");
            }
        }

        public void DoorClosed()
        {
            doorClosed = true;
            Console.WriteLine("door is closed");

        }

        public void DoorOpen()
        {
            doorClosed = false;
            Console.WriteLine("door is open");
            CloseDoor();
        }
    }
}
