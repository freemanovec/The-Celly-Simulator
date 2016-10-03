using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Celly_Simulator
{
    public class Cell
    {
        private double _energy;
        private double _food;
        private ulong _lifetime;
        private string _dna;
        private uint _level;

        public double energy
        {
            get
            {
                return _energy;
            }
            set
            {
                _energy = value;
            }
        }
        public double food
        {
            get
            {
                return _food;
            }
            set
            {
                _food = value;
            }
        }
        public ulong lifetime
        {
            get
            {
                return _lifetime;
            }
        }
        public string dna
        {
            get
            {
                return _dna;
            }
        }
        public uint level
        {
            get
            {
                return _level;
            }
        }


        public double foodBurnupRate = 0.2d;
        public double energyBurnupRate = 0.175d;
        public double minEnergyNeededToLive = 15d;
        
        private double defaultEnergy = 250d;
        private double defaultFood = 15d;


        public bool debug = false;

        public enum DeathReasons { OutOfEnergy, Killed}

        public Cell()
        {
            this._energy = defaultEnergy;
            this._food = defaultFood;
            this._lifetime = 0;
            this._dna = Helper.GenerateCellDNA();
        }
        public Cell(bool passedDebug)
        {
            this._energy = defaultEnergy;
            this._food = defaultFood;
            this._lifetime = 0;
            this.debug = passedDebug;
            this._dna = Helper.GenerateCellDNA();
        }
        public Cell(double passedEnergy,double passedFood,ulong passedLifetime)
        {
            this._energy = passedEnergy;
            this._food = passedFood;
            this._lifetime = passedLifetime;
            this._dna = Helper.GenerateCellDNA();
        }
        public Cell(double passedEnergy, double passedFood, ulong passedLifetime,bool passedDebug)
        {
            this._energy = passedEnergy;
            this._food = passedFood;
            this._lifetime = passedLifetime;
            this.debug = passedDebug;
            this._dna = Helper.GenerateCellDNA();
        }
        public Cell(double passedEnergy, double passedFood)
        {
            this._energy = passedEnergy;
            this._food = passedFood;
            this._lifetime = 0;
            this._dna = Helper.GenerateCellDNA();
        }
        public Cell(double passedEnergy, double passedFood,bool passedDebug)
        {
            this._energy = passedEnergy;
            this._food = passedFood;
            this._lifetime = 0;
            this.debug = passedDebug;
            this._dna = Helper.GenerateCellDNA();
        }

        public void Begin()
        {
            AssignRandomDNA();
        }
        public void AssignRandomDNA()
        {
            _dna = Helper.GenerateCellDNA();
        }
        void CreateEnergyFromFood()
        {
            if (food - foodBurnupRate <= 0d)
            {
                if (energy < minEnergyNeededToLive)
                {
                    Kill(DeathReasons.OutOfEnergy);
                }
            }
            else
            {
                food -= foodBurnupRate;
                energy += foodBurnupRate;
            }
        }
        void CreateEnergyFromFood(double effectivity)
        {
            if (food - foodBurnupRate <= 0d)
            {
                if (energy < minEnergyNeededToLive)
                {
                    Kill(DeathReasons.OutOfEnergy);
                }
            }
        }
        public bool DrainEnergy(double energyToDrain,bool fatal)
        {
            if (fatal)
            {
                if (energy < minEnergyNeededToLive - energyToDrain)
                {
                    Kill(DeathReasons.OutOfEnergy);
                    return false;
                }
                else
                {
                    energy -= energyToDrain;
                    return true;
                }
            }
            else
            {
                if (energy > minEnergyNeededToLive - energyToDrain)
                {
                    energy -= energyToDrain;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool DrainFood(double foodToDrain)
        {
            if (food > foodToDrain)
            {
                food -= foodToDrain;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Tick()
        {
            DoTheTickingStuff();
        }
        public void Tick(int times)
        {
            for (int i = 0; i < times; i++)
            {
                DoTheTickingStuff();
            }
        }
        private void DoTheTickingStuff()
        {
            CreateEnergyFromFood();
            DrainEnergy(energyBurnupRate, true);
            _lifetime += 1;
            DebugStuff();
        }
        public void Kill(DeathReasons reason)
        {
            switch (reason)
            {
                case DeathReasons.OutOfEnergy:
                    Program.RemoveCellFromList(this);
                    break;
            }
        }
        public void DebugStuff()
        {
            if (debug)
            {
                Program.ShowStatsOfCell(this);
            }
        }
    }
}
