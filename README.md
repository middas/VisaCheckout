# VisaCheckout 
This is a simple way to integrate Visa Checkout into your ASP.NET MVC website.  This project includes unit tests and an example website of usage.

## Minimal Setup
```c#
@{
	VisaCheckout.VisaHelper.Options.OnOptions onOptions = new VisaCheckout.VisaHelper.Options.OnOptions
	{
		PaymentSuccess = string.Format("postResults(JSON.stringify(payment), '{0}');", Url.Action("Success")),
		PaymentCancel = string.Format("postResults(JSON.stringify(payment), '{0}');", Url.Action("Cancel")),
		PaymentError = string.Format("postResults(JSON.stringify(payment), '{0}');", Url.Action("Error"))
	};

	decimal subtotal = 21.57M;

	VisaCheckout.VisaHelper.Options.VisaOptions minOptions = new VisaCheckout.VisaHelper.Options.VisaOptions("public_key", subtotal, VisaCheckout.VisaHelper.Options.CurrencyCodes.USD, onOptions);
}
@Html.WriteVisaCheckoutLink(minOptions)
```

If you wish to contribute to the project, please submit your pull request to the development branch.