using Project.Models;
using System;

namespace Project.Data
{
    public class PokemonFactory
    {
        DbHandler handler;
        public PokemonFactory() {
            handler = new DbHandler();
        }

        public Pokemon GetPokemonByName(string name) {
            DbRecord record = handler.GetRecordByName(name);

            Pokemon pokemon = new Pokemon(
                CheckNull(record.Number, "Number"), 
                CheckNull(record.Name, "Name"), 
                GetType(record.Type_1, true), 
                GetType(record.Type_2), 
                CheckNull(record.Description, "Description"), 
                CheckNull(record.Weight, "Weight"),
                CheckNull(record.Height, "Height"),
                CheckNullInt(record.Level,"Level"), 
                CheckNullInt(record.HP, "HP"), 
                CheckNull(record.Pre_Evolution, "Pre-Evolution"), 
                CheckNull(record.Evolution, "Evolution"), 
                GetRarity(record.Status), 
                CheckNull(record.Move1, "Move 1"), 
                CheckNull(record.Move2, "Move 2"),
                CheckNull(record.Move3, "Move 3"), 
                CheckNull(record.Move4, "Move 4"), 
                CheckNull(record.Image, "Image")
            );    

            return pokemon;
        }

        private Rarity GetRarity(string rarity) {
            if(string.IsNullOrEmpty(rarity))
                return Rarity.Unknown;

            return (Rarity) Enum.Parse(typeof(Rarity), rarity, true);
        }

        private Type GetType(string type, bool required=false) {
            try {
                return (Type) Enum.Parse(typeof(Type), type, true);
            } catch (ArgumentException e) {
                if (!required) {
                    return Type.Null;
                }
                throw new InvalidPokemonRecordException("Record found with invalid Type");
            }
        }

        private string CheckNull(string fieldContent, string fieldName) {
            if (string.IsNullOrEmpty(fieldContent))
                throw new InvalidPokemonRecordException("Record found with invalid field: " + fieldName);
            else return fieldContent;
        }

        private uint CheckNullInt(string fieldContent, string fieldName) {
            if (string.IsNullOrEmpty(fieldContent))
                throw new InvalidPokemonRecordException("Record found with invalid field: " + fieldName);
            else return Convert.ToUInt32(fieldContent);
        }


    }
}