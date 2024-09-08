using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet {
    public class Pet {
        public string Name { get; set; } = "unnamed pet";
        public int HungerLevel { get; set; } = 50;
        public int HappinessLevel { get; set; } = 50;
        public int EnergyLevel { get; set; } = 50;

        // Declare delegate
        public delegate void UpdatePet(Pet myPet);

        // Declare events
        public event UpdatePet FeedPet;
        public event UpdatePet PlayWithPet;
        public event UpdatePet PutToSleep;

        public void FeedCaller(Pet myPet) { // this method raises the FeedPet event which has Feed (a handler) subscribed to it
            FeedPet?.Invoke(myPet);
        }

        public void PlayCaller(Pet myPet) { // this method raises the PlayWithPet event which has Play (a handler) subscribed to it
            PlayWithPet?.Invoke(myPet);
        }

        public void SleepCaller(Pet myPet) { // this method raises the PutToSleep event which has Sleep (a handler) subscribed to it
            PutToSleep?.Invoke(myPet);
        }
    }
}
