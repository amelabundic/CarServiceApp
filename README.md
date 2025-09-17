# AutoCentarBundic

AutoCentarBundic je web aplikacija razvijena s ciljem da olakša proces zakazivanja termina u autoservisu.  
Aplikacija korisnicima omogućava jednostavno upravljanje svojim servisnim terminima putem intuitivnog korisničkog interfejsa.

## Funkcionalnosti

- Registracija i prijava korisnika  
- Korisnički profil s pregledom svih zakazanih termina, s mogućnošću:  
  - zakazivanja novog termina,  
  - pregleda detalja već zakazanih termina,  
  - brisanja postojećih termina 
- CRUD operacije nad terminima (dodavanje, pregled detalja, izmjena, brisanje)  
- Pregled svih zakazanih termina na početnoj stranici  
- Zakazivanje novog termina direktno sa početne stranice  

### Planirane funkcionalnosti (u razvoju)

- Real-time praćenje statusa popravke automobila  
- Chatbot podrška korisnicima  
- AI dijagnoza (unos problema → procjena mogućeg kvara, trajanja i okvirne cijene popravke)  

## Korištene tehnologije

- **ASP.NET Core**  
- **Blazor**  
- **Entity Framework Core (SQL baza)**  
- **Bootstrap, CSS, HTML**  

## Pokretanje projekta

1. Klonirati repozitorij:  
   ```bash
   git clone https://github.com/amelabundic/CarServiceApp.git

2. Ući u projekat:
   cd CarServiceApp/AutoCentarBundic

3.Pokrenuti aplikaciju kroz Visual Studio ili pomoću .NET CLI:
  dotnet run


