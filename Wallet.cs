﻿using System;

namespace LemonadeStandV2
{
    public class Wallet
    {
        private double money;

        public double Money
        { get => money;
            set => money = value;
        }


        public Wallet()
        {
            money = 20;
        }


        public bool CheckWallet(double price)



    }
}