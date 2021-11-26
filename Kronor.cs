﻿using System;

namespace Lektion2
{
    public class Kronor
    {
        /*
         * Totala värdet i öre. 
         * När vi väl har skapat ett Kronor-objekt ska det aldrig kunna ändras
         */

        //private readonly int öre;
        private int öre { get; }

        // Skapar tom Kronor
        public Kronor()
        {

        }
        // Skapar kopia av en annan Kronor
        public Kronor(Kronor kronor)
        {
            öre = kronor.ÖrenPart() + kronor.KronorPart() * 100;
        }
        /*
         * Skapar Kronor med initialt värde
         */
        public Kronor(int kronor, int öre)
        {
            this.öre = kronor + öre * 100;
        }

        /*
         * Returnerar kronordelen av kronorna
         */
        public int KronorPart()
        {
            return öre / 10;
        }

        /*
         * Returnerar öresdelen av kronorna
         */
        public int ÖrenPart()
        {
            return öre % 10;
        }
        /*
         * Adderar den här Kronor med other och returnerar resultatet
         */
        public Kronor Add(Kronor other)
        {
            var temp = (this.ÖrenPart() + other.ÖrenPart()) + 
                (this.KronorPart() + other.KronorPart() * 100);
            var tempKronor = temp / 100;
            var tempÖren = temp % 100;

            return new Kronor(tempKronor, tempÖren);
        }

        public Kronor Subtract(Kronor other)
        {
            var temp = (this.ÖrenPart() - other.KronorPart()) + 
                (this.KronorPart() * 100 - other.ÖrenPart() * 10);
            var tempKronor = temp / 100;
            var tempÖren = temp % 100;

            return new Kronor(tempKronor, tempÖren);
        }
        /*
         * Returnerar sant om kronorna har ett positivt värde
         */
        public bool IsPositive()
        {
            return öre > 0;
        }

        /*
         * Returnerar sant om kronorna har ett negativt värde
         */
        public bool isNegative()
        {
            return öre < 0;
        }

        /*
         * Returnerar sant om kronorna har ett värde på 0
         */
        public bool IsZero()
        {
            return öre == 0;
        }
    }
}
