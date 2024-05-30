using System.Collections.Generic;

namespace UnitsLDL
{
    public interface IStatModifier
    {
        float ValueModifier { get; }
        List<StructModifier> StatModifiers { get; }
        void AddModifier ( StructModifier modifier);
        void AddModifiers( List<StructModifier> modifiers);
        bool RemoveModifier ( StructModifier modifier);
        void CalculeModifier();
    }
}

