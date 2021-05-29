# SelfServiceCheckout
BeforeStart  
DigitalThinkers.SelfServiceCheckout.Data -> Developer PowerShell / Developer Command Prompt -> dotnet ef database update  
Run DigitalThinkers.SelfServiceCheckout\Data\Seed SelfServiceCheckoutDbSeed.sql  

Features:  
/api/v{version}/Stock Get Return current lcy stock  
/api/v{version}/Stock Post Add or update banknotes to stock  
e.g.  
{  
&nbsp;&nbsp;"inserted": [  
&nbsp;&nbsp;&nbsp;&nbsp;{  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"valueInTCY": 1000,  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"amount": 1000  
&nbsp;&nbsp;&nbsp;&nbsp;},  
&nbsp;&nbsp;&nbsp;&nbsp;{  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"valueInTCY": 2000,  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"amount": 1000  
&nbsp;&nbsp;&nbsp;&nbsp;}  
&nbsp;&nbsp;]  
}  
/api/v{version}/Checkout Post Give back change or throw error in case: price not provided, not enough money inserted, cannot get change  
{  
&nbsp;&nbsp;"inserted": [  
&nbsp;&nbsp;&nbsp;&nbsp;{  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"valueInTCY": 4,  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"amount": 2000  
&nbsp;&nbsp;&nbsp;&nbsp;}  
&nbsp;&nbsp;],  
&nbsp;&nbsp;"price": 7000  
}  
