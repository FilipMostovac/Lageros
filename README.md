# Lageros

##

UPUTE SA SLIKAMA: https://docs.google.com/document/d/1RleDA6U1u---_dwIAmjKDO7pm2gm7nlV/edit?usp=sharing&ouid=106441156201221806964&rtpof=true&sd=true

1.	Potrebno je instalirati VisualStudio Community 2019 (Ako ga nemate instaliranog)
    https://visualstudio.microsoft.com/downloads/
2.	Prilikom instalacije potrebno je instalirati ASP.NET and web development paket
 
3.	Potrebno je instalirati Microsoft SQL Server 2019 Express 
    https://www.microsoft.com/en-us/Download/details.aspx?id=101064
 
4.	Nakon što završi instalacija Microsoft SQL Server 2019 Express-a, potrebno je instalirati SQL Server Management Studio – pritiskom na gumb Install SSMS i preuzimanjem sa linka
 
5.	Pokrenite kloniranje repozitorija sa GitHub-a
 
    Upišite u polje Repository location -> https://github.com/FilipMostovac/Lageros.git -> Clone
 
6.	Nakon što smo instalirali sve tražene programe i klonirali projekt, otvorimo project koji smo klonirali i pričekamo da se svi dependencies instaliraju

7.	Tools -> NuGet Package Manager -> Package Manager Console
 
    Otvara se terminal na dnu ekrana u koji moramo upisati dve naredbe:
    •	Update-Database -Context LagerosContext
    •	Update-Database -Context AuthDbContext
 
8.	Otvorite SQL Server Management Studio -> Spojite se na server koji je zadani
 
9.	Odaberite New Query
 
10.	Upišite slijedeću naredbu:
    INSERT INTO Izbor (NazivPeriferije) VALUES ('Miš'), ('Tipkovnica'), ('Slušalice'), ('Kabel');
 
11.	Pokrećemo naredbu na gumb Execute
 
12.	Otovrimo VisualStudio i pokrećemo aplikaciju na Gumb IIS Express
 
13.	Prilikom prvog pokretanje potrebno je isntalirat SSL certifikat -> Yes
14.	Kako bi aplikacija uredno radila potrebno je:

    a) Unesite novi sektor u aplikaciju

    b) Unesite novog zaposlenika u aplikaciju
 
    c) Unesite novog administratora u aplikaciju

 
 

 
