﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CodeGeneration.GenerationResult.T4.HostSpecific
{

    using System.Collections.Generic;

    public class Tiger
    {
        private IEnumerable<int> preyIds;

        public Tiger(string name)
        {
            Name = name;
        }

        public string Name {get; set;}

        public int NumberOfLegs => 4;

        public IEnumerable<int> PreyIds => preyIds ?? (preyIds = new List<int>
        {
           2,
        });
    }
}

