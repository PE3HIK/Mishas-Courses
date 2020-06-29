using System;
using System.Collections.Generic;
using UnityEngine;
    public class Damage  
    {
        
        public readonly int amount; // поле 
        public readonly bool isPure;

        public Damage( int amount, bool isPure = false) // Это конструктор 
        {
            this.amount = amount; // инициализация поля 
            this.isPure = isPure;
        }
    }
