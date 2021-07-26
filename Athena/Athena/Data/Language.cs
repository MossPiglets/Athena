using Athena.EnumLocalizations;
using Athena.Resources;
using System.ComponentModel;

namespace Athena.Data {
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum Language {
        [LocalizedDescription("PL", typeof(Languages))]
        PL,

        [LocalizedDescription("EN", typeof(Languages))]
        EN,

        [LocalizedDescription("RU", typeof(Languages))]
        RU,

        [LocalizedDescription("FR", typeof(Languages))]
        FR,

        [LocalizedDescription("DE", typeof(Languages))]
        DE,

        [LocalizedDescription("AF", typeof(Languages))]
        AF,

        [LocalizedDescription("AR", typeof(Languages))]
        AR,

        [LocalizedDescription("BE", typeof(Languages))]
        BE,

        [LocalizedDescription("BG", typeof(Languages))]
        BG,

        [LocalizedDescription("BN", typeof(Languages))]
        BN,

        [LocalizedDescription("BR", typeof(Languages))]
        BR,

        [LocalizedDescription("BS", typeof(Languages))]
        BS,

        [LocalizedDescription("CA", typeof(Languages))]
        CA,

        [LocalizedDescription("CS", typeof(Languages))]
        CS,

        [LocalizedDescription("CY", typeof(Languages))]
        CY,

        [LocalizedDescription("DA", typeof(Languages))]
        DA,

        [LocalizedDescription("EL", typeof(Languages))]
        EL,

        [LocalizedDescription("EO", typeof(Languages))]
        EO,

        [LocalizedDescription("ES", typeof(Languages))]
        ES,

        [LocalizedDescription("ET", typeof(Languages))]
        ET,

        [LocalizedDescription("FI", typeof(Languages))]
        FI,

        [LocalizedDescription("GA", typeof(Languages))]
        GA,

        [LocalizedDescription("GL", typeof(Languages))]
        GL,

        [LocalizedDescription("HE", typeof(Languages))]
        HE,

        [LocalizedDescription("HR", typeof(Languages))]
        HR,

        [LocalizedDescription("HU", typeof(Languages))]
        HU,

        [LocalizedDescription("IT", typeof(Languages))]
        IT,

        [LocalizedDescription("JA", typeof(Languages))]
        JA,

        [LocalizedDescription("KO", typeof(Languages))]
        KO,

        [LocalizedDescription("LT", typeof(Languages))]
        LT,

        [LocalizedDescription("LV", typeof(Languages))]
        LV,

        [LocalizedDescription("MK", typeof(Languages))]
        MK,

        [LocalizedDescription("MN", typeof(Languages))]
        MN,

        [LocalizedDescription("MS", typeof(Languages))]
        MS,

        [LocalizedDescription("PT", typeof(Languages))]
        NE,

        [LocalizedDescription("NL", typeof(Languages))]
        NL,

        [LocalizedDescription("NN", typeof(Languages))]
        NN,

        [LocalizedDescription("PT", typeof(Languages))]
        PT,

        [LocalizedDescription("RO", typeof(Languages))]
        RO,

        [LocalizedDescription("SH", typeof(Languages))]
        SH,

        [LocalizedDescription("SK", typeof(Languages))]
        SK,

        [LocalizedDescription("SL", typeof(Languages))]
        SL,

        [LocalizedDescription("SQ", typeof(Languages))]
        SQ,

        [LocalizedDescription("SR", typeof(Languages))]
        SR,

        [LocalizedDescription("SV", typeof(Languages))]
        SV,

        [LocalizedDescription("SW", typeof(Languages))]
        SW,

        [LocalizedDescription("TH", typeof(Languages))]
        TH,

        [LocalizedDescription("TR", typeof(Languages))]
        TR,

        [LocalizedDescription("UK", typeof(Languages))]
        UK,

        [LocalizedDescription("VI", typeof(Languages))]
        VI,

        [LocalizedDescription("ZH", typeof(Languages))]
        ZH,

        [LocalizedDescription("AM", typeof(Languages))]
        AM,

        [LocalizedDescription("AZ", typeof(Languages))]
        AZ,

        [LocalizedDescription("Other", typeof(Languages))]
        Other
    }
}