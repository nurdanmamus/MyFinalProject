using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    //java'da bir method statikse class'da static olmalı
    //ama c# da öyle değil 
    public class BusinessRules  
    {
        //params metotların değişken sayıda parametre almasına
        //imkan veren bir anahtar kelimedir. 
        public static IResult Run(params IResult[] logics)  
        { 
            foreach (var logic in logics)  
            {
                if (!logic.Success) 
                {
                    //error result döndürecek 
                    return logic; 
                }
            }
            return null; 
        }
    }
}
