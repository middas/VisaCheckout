using System;

namespace VisaCheckout.VisaHelper.Options
{
    public enum ApiKeyStatus
    {
        ACTIVE,
        INACTIVE
    }

    [Flags]
    public enum BillingCountries
    {
        /// <summary>
        /// Argentina
        /// </summary>
        AR = 1,

        /// <summary>
        /// Australia
        /// </summary>
        AU = 2,

        /// <summary>
        /// Brazil
        /// </summary>
        BR = 4,

        /// <summary>
        /// Canada
        /// </summary>
        CA = 8,

        /// <summary>
        /// China
        /// </summary>
        CN = 16,

        /// <summary>
        /// Chile
        /// </summary>
        CL = 32,

        /// <summary>
        /// Colombia
        /// </summary>
        CO = 64,

        /// <summary>
        /// Hong Kong
        /// </summary>
        HK = 128,

        /// <summary>
        /// Malaysia
        /// </summary>
        MY = 256,

        /// <summary>
        /// Mexico
        /// </summary>
        MX = 512,

        /// <summary>
        /// New Zealand
        /// </summary>
        NZ = 1024,

        /// <summary>
        /// Peru
        /// </summary>
        PE = 2048,

        /// <summary>
        /// Singapore
        /// </summary>
        SG = 4096,

        /// <summary>
        /// South Africa
        /// </summary>
        ZA = 8192,

        /// <summary>
        /// United Arab Emirates
        /// </summary>
        AE = 16384,

        /// <summary>
        /// United States
        /// </summary>
        US = 32768
    }

    /// <summary>
    /// Possible button actions on the Review page
    /// </summary>
    public enum ButtonActions
    {
        /// <summary>
        /// Display Continue on the lightbox button (default)
        /// </summary>
        Continue,

        /// <summary>
        /// Pay - Display Pay on the lightbox button
        ///
        /// Note: A value for total must be specified; otherwise Continue will be displayed.
        /// </summary>
        Pay
    }

    /// <summary>
    /// Preset colors of the button.
    /// </summary>
    public enum ButtonColors
    {
        /// <summary>
        /// The standard colors (default)
        /// </summary>
        Standard,

        /// <summary>
        /// Neutral colors
        /// </summary>
        Neutral
    }

    /// <summary>
    /// Preset widths of the button.
    /// </summary>
    public enum ButtonSizes
    {
        /// <summary>
        /// 154 pixels
        /// </summary>
        Small = 154,

        /// <summary>
        /// 213 pixels (default)
        /// </summary>
        Medium = 213,

        /// <summary>
        /// 425 pixels
        /// </summary>
        Large = 425,

        /// <summary>
        /// Custom size defined by Width and Height properties.
        /// </summary>
        Custom
    }

    /// <summary>
    /// Possible currency code values
    /// </summary>
    public enum CurrencyCodes
    {
        /// <summary>
        /// US dollars
        /// </summary>
        USD,

        /// <summary>
        /// Canadian dollars
        /// </summary>
        CAD,

        /// <summary>
        /// Australian dollars
        /// </summary>

        AUD,
        /// <summary>
        /// Argentine Peso
        /// </summary>

        ARS,
        /// <summary>
        /// Brazilian Real
        /// </summary>

        BRL,
        /// <summary>
        /// Yuan Renminbi
        /// </summary>

        CNY,
        /// <summary>
        /// Chilean Peso
        /// </summary>

        CLP,
        /// <summary>
        /// Colombian Peso
        /// </summary>

        COP,
        /// <summary>
        /// Hong Kong Dollar
        /// </summary>

        HKD,
        /// <summary>
        /// Malaysian Ringgit
        /// </summary>

        MYR,
        /// <summary>
        /// Mexican Peso
        /// </summary>

        MXN,
        /// <summary>
        /// New Zealand Dollar
        /// </summary>

        NZD,
        /// <summary>
        /// Nuevo Sol - Peru
        /// </summary>

        PEN,
        /// <summary>
        /// Singapore Dollar
        /// </summary>

        SGD,

        /// <summary>
        /// Rand
        /// </summary>
        ZAR,

        /// <summary>
        /// UAE Dirham
        /// </summary>
        AED
    }

    /// <summary>
    /// The response data level values.
    /// </summary>
    public enum DataLevels
    {
        /// <summary>
        /// Summary information (default)
        /// </summary>
        SUMMARY,

        /// <summary>
        /// Full information, which is only available if you are configured to receive it.
        /// </summary>
        FULL,

        /// <summary>
        /// Consumer and payment information is not returned in the payment.success event response, in which case the Get Payment Data API must be used to obtain the information.
        /// </summary>
        NONE
    }

    /// <summary>
    /// Event status types
    /// </summary>
    public enum EventStatuses
    {
        Success,
        Failure,
        Fraud,
        Chargeback,
        Other
    }

    /// <summary>
    /// Transaction event types
    /// </summary>
    public enum EventTypes
    {
        Create,
        Confirm,
        Cancel,
        Fraud,
        Other
    }

    /// <summary>
    /// Event types specific for Payments
    /// </summary>
    public enum PayEventTypes
    {
        Authorize,
        Capture,
        Refund,
        Cancel,
        Fraud,
        Chargeback,
        Other
    }

    /// <summary>
    /// The cards that you support charging.
    /// </summary>
    [Flags]
    public enum SupportedCards
    {
        VISA = 1,
        AMEX = 2,
        MASTERCARD = 4,
        DISCOVER = 8
    }
}