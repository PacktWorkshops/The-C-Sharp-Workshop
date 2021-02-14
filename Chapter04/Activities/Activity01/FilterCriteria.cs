using System;

namespace Chapter04.Activities.Activity01
{
    internal enum FilterCriteriaType
    {
        Class,
        Origin,
        Destination
    }

    internal record FilterCriteria(FilterCriteriaType Filter, string Operand);

}
