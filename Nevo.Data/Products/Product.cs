namespace Nevo.Data.Products
{
    /// <summary>
    ///     Product.
    /// </summary>
    public sealed record Product
    {
        /// <summary>
        ///     Product code.
        /// </summary>
        public int Code { get; init; }

        /// <summary>
        ///     Code of the group this product belongs to.
        /// </summary>
        public int GroupCode { get; init; }

        /// <summary>
        ///     Description of the group this product belongs to (English).
        /// </summary>
        public string? GroupDescriptionEn { get; init; }

        /// <summary>
        ///     Description of the group this product belongs to (Dutch).
        /// </summary>
        public string? GroupDescriptionNl { get; init; }

        /// <summary>
        ///     Product-identity English.
        /// </summary>
        public string? DescriptionEn { get; init; }

        /// <summary>
        ///     Product-identity Dutch (name, cooking method, packaging).
        /// </summary>
        public string? DescriptionNl { get; init; }

        /// <summary>
        ///     Synonyms in English.
        /// </summary>
        public string? SynonymsEn { get; init; }

        /// <summary>
        ///     Synonyms in Dutch.
        /// </summary>
        public string? SynonymsNl { get; init; }

        /// <summary>
        ///     Extra information (if present).
        /// </summary>
        public string? CommentsEn { get; init; }

        /// <summary>
        ///     Extra information (if present).
        /// </summary>
        public string? CommentsNl { get; init; }

        /// <summary>
        ///     When a product is enriched with one or more nutrient(s) the
        ///     applicable nutrients are mentioned in this field.
        /// </summary>
        public string? EnrichedWithEn { get; init; }

        /// <summary>
        ///     When a product is enriched with one or more nutrient(s) the
        ///     applicable nutrients are mentioned in this field.
        /// </summary>
        public string? EnrichedWithNl { get; init; }

        /// <summary>
        ///     Trace: some nutrients are present in a very low amount (analyse
        ///     below detection) in a product; this is shown as trace.
        ///     A 0,0 is placed as value of the nutrient, so you can calculate with the
        ///     amount.
        /// </summary>
        public string? TraceAmounts { get; init; }

        /// <summary>
        ///     Energy in kcal. Calculated by macro nutrient factors.
        ///     1 gram protein = 4 kcal
        ///     1 gram fat = 9 kcal
        ///     1 gram carbohydrates = 4 kcal
        ///     1 gram dietary fiber = 2 kcal
        ///     1 gram alcohol = 7 kcal
        ///     1 gram polyols = 2.4 kcal
        ///     1 gram organic acids = 3 kcal
        /// </summary>
        public double EnergyKcal { get; init; }

        /// <summary>
        ///     Energy in kJ. Calculated by macro nutrient factors.
        ///     1 gram protein = 17 kJ
        ///     1 gram fat = 37 kJ
        ///     1 gram carbohydrates = 17 kJ
        ///     1 gram dietary fiber = 8 kJ
        ///     1 gram alcohol = 29 kJ
        ///     1 gram polyols = 10 kJ
        ///     1 gram organic acids = 13 kj
        /// </summary>
        public double EnergyKj { get; init; }
    }
}