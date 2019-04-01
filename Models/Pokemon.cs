using System;
using System.Collections.Generic;
using System.Linq;
using Project.interfaces;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Threading.Tasks;

namespace Project.Models{
    public class Pokemon : IPokemon {
        public uint Number { get; private set; }
        public string Name { get; private set; }
        public Type Type1 { get; private set; }
        public Type Type2 { get; private set; } = Type.Null;
        public string Description {get; private set;}
        public double Weight {get;private set;}
        public double Height {get;private set;}
        public uint Level { get; private set; }
        public uint Hp { get; private set; }
        public string PreEvolution { get; private set; }
        public string Evolution { get; private set; }
        public Rarity RarityOf{get;private set;}
        public string Move1{get;private set;}
        public string Move2{get;private set;}
        public string Move3{get;private set;}
        public string Move4{get;private set;}   
        public string Weaknesses{ get; set; }
        public string Strengths{ get; set; }
        public string Image { get; private set; }
        public double IV { get; private set; }
        
    public Pokemon
    ( uint number, string name, Type type1, Type type2, string description, double weight,
        double height, uint level, uint hp, string preEvolution, string evolution, Rarity rarityOf,
        string move1, string move2, string move3, string move4, string image )
      {
            this.Number = number;
            this.Name = name;
            this.Type1 = type1;
            this.Type2 = type2;
            this.Description = description;
            this.Weight = weight;
            this.Height = height;
            this.Level = level;
            this.Hp = hp;
            this.PreEvolution = preEvolution;
            this.Evolution = evolution;
            this.RarityOf = rarityOf;
            this.Move1 = move1;
            this.Move2 = move2;
            this.Move3 = move3;
            this.Move4 = move4;
            this.Image = image;
            this.IV = getIV();
      }

     public double getIV(){
        Random random = new Random();  
        int attack = random.Next(1, 15); 
        int defense = random.Next(1, 15); 
        return((Convert.ToInt32(this.Hp)+attack+defense)/45);
     }

        // public void setStrengths(string[] str) {
        //     this.Strengths = new Type[str.Length];
        //     for (int i = 0; i < str.Length; i++)
        //         this.Strengths[i] = (Type)Enum.Parse(typeof(Type), str[i], true);
        // }

        // public void setWeaknesses(string[] str)
        // {
        //     this.Weaknesses = new Type[str.Length];
        //     for (int i = 0; i < str.Length; i++)
        //         this.Weaknesses[i] = (Type)Enum.Parse(typeof(Type), str[i], true);
        // }

        // public infoToSpeech(){
        //     SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        //         synthesizer.Volume = 100;  // 0...100
        //         synthesizer.Rate = -2;     // -10...10

        //         // Synchronous
        //         synthesizer.Speak(this.name);

        //         synthesizer.Speak("Pokedex number "+this.number.ToString());

        //         synthesizer.Speak("Type "+this.type);
        //         // Asynchronous
        //         synthesizer.SpeakAsync(this.description);
        // }

        //  public Pokemon evolve() {
        //         return new Pokemon(Data Evo);
        //     }

        //  public Pokemon devolve() {
        //         return new Pokemon(Data Pre);
        //     }

    }

}