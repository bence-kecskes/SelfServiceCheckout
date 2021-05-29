# SelfServiceCheckout
BeforeStart
DigitalThinkers.SelfServiceCheckout.Data -> Developer PowerShell / Developer Command Prompt -> dotnet ef database update
Run DigitalThinkers.SelfServiceCheckout\Data\Seed SelfServiceCheckoutDbSeed.sql

Features:
/api/v{version}/Stock Get Return current lcy stock
/api/v{version}/Stock Post Add or update banknotes to stock
e.g.
{
  "inserted": [
    {
      "valueInTCY": 1000,
      "amount": 1000
    },
    {
      "valueInTCY": 2000,
      "amount": 1000
    }
  ]
}
/api/v{version}/Checkout Post Give back change or throw error in case: price not provided, not enough money inserted, cannot get change
{
  "inserted": [
    {
      "valueInTCY": 4,
      "amount": 2000
    }
  ],
  "price": 7000
}
