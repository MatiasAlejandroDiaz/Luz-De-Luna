using System.Collections.Generic;

namespace UnitsLDL
{
    //CLASE QUE MANEJA LA FORMA DE APLICAR Y DESAPLICAR MODIFICADORES DE STATS
    //EJEMPLO DE MODIFICADORES DE VIDA : +10% VIDA , +200 DE VIDA
    internal class NormalStatModifier : IStatModifier
    {
        float valorInicial;
        //VALOR TOTAL DEL STAT CON LOS MODIFICADORES Aplicados
        float valueModifier;
        List<StructModifier> statModifiers;

        public NormalStatModifier(float valorInicial)
        {
            this.valorInicial = valorInicial;
            valueModifier = 0;
            statModifiers = new List<StructModifier>();
        }

        public NormalStatModifier(float valorInicial, List<StructModifier> statModifiers)
        {
            this.valorInicial = valorInicial;
            valueModifier = 0;
            this.statModifiers = new List<StructModifier>();
            this.statModifiers.AddRange(statModifiers);
            CalculeModifier();
        }

        public float ValueModifier { get { CalculeModifier(); return valueModifier; } }

        public List<StructModifier> StatModifiers => statModifiers;

        public void AddModifier(StructModifier modifier)
        {
            statModifiers.Add( modifier );
            CalculeModifier();
        }

        public void AddModifiers(List<StructModifier> modifiers)
        {
            statModifiers.AddRange(modifiers);
            CalculeModifier();
        }
        public void CalculeModifier()
        {
            valueModifier = 0;

            foreach(StructModifier modifier in statModifiers)
            {
                valueModifier += modifier.ValueModd; 
            }
        }

        public bool RemoveModifier(StructModifier modifier)
        {
            bool result = statModifiers.Remove( modifier );
            if (!result) { UnityEngine.Debug.LogError("No se Pudo Remover el Modificador "+modifier.DescModd+" de el Atributo."); }
            CalculeModifier();
            return result;

        }

    }
}

