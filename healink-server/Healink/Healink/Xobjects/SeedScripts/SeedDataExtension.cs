using Healink.Data;
using Healink.Entities;
using Healink.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Healink.Xobjects.SeedScripts
{
    public static class SeedDataExtension
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DataContext>();

            #region Roles
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(new Role { RoleName = "AdminUser" });
                context.Roles.AddRange(new Role { RoleName = "PersonalUser" });
                context.Roles.AddRange(new Role { RoleName = "Organization" });
                context.SaveChanges();
            }
            #endregion

            #region Users
            if (!context.Users.Any(o => o.Username == "superuser"))
            {
                context.Users.AddRange(new User { Username = "superuser", Email = "sup@1.com", Password = PasswordHasher.HashPassword("superuser@1"), LastLogin = DateTime.Now, CreatedDate = DateTime.Now, IsActive = true, IsVerified = true, RoleId = 1, RefreshToken="ddaxcdfwev", RefreshTokenExpiry=DateTime.Now});
                context.SaveChanges();
            }
            if (!context.Users.Any(o => o.Username == "healink"))
            {
                context.Users.AddRange(new User { Username = "healink", Email = "healink@gmail.com", Password = PasswordHasher.HashPassword("healink@1"), LastLogin = DateTime.Now, CreatedDate = DateTime.Now, IsActive = true, IsVerified = true, RoleId = 3, RefreshToken = "jyhwjfne", RefreshTokenExpiry = DateTime.Now });
                context.SaveChanges();
            }
            #endregion

            #region IndustryTypes
            if (!context.IndustryTypes.Any())
            {
                context.IndustryTypes.AddRange(new IndustryType { IndustryName = "Health System", CreatedDate =DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.IndustryTypes.AddRange(new IndustryType { IndustryName = "Clinics", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.IndustryTypes.AddRange(new IndustryType { IndustryName = "Nursing Home", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.IndustryTypes.AddRange(new IndustryType { IndustryName = "Ambulatory Care Center", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 }); 
                context.IndustryTypes.AddRange(new IndustryType { IndustryName = "Hospital", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.IndustryTypes.AddRange(new IndustryType { IndustryName = "Health Insurance", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.IndustryTypes.AddRange(new IndustryType { IndustryName = "Public Health Agency", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.IndustryTypes.AddRange(new IndustryType { IndustryName = "Nonprofit Organization", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.IndustryTypes.AddRange(new IndustryType {IndustryName = "Research Institution", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.IndustryTypes.AddRange(new IndustryType {IndustryName = "Regulatory Agency", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.IndustryTypes.AddRange(new IndustryType {IndustryName = "Medical Device Company", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.IndustryTypes.AddRange(new IndustryType {IndustryName = "Rehabilitation Center", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.IndustryTypes.AddRange(new IndustryType {IndustryName = "Mental Health Center", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.IndustryTypes.AddRange(new IndustryType {IndustryName = "Home Healthcare Agency", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.IndustryTypes.AddRange(new IndustryType {IndustryName = "Telemedicine Company", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.IndustryTypes.AddRange(new IndustryType {IndustryName = "Medical Laboratory", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.IndustryTypes.AddRange(new IndustryType {IndustryName = "Healthcare Consulting Firm", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.IndustryTypes.AddRange(new IndustryType {IndustryName = "Health Information Technology (HIT) Company", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.IndustryTypes.AddRange(new IndustryType {IndustryName = "Medical Schools and Academic Medical Center", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.IndustryTypes.AddRange(new IndustryType {IndustryName = "Healthcare Foundation", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.IndustryTypes.AddRange(new IndustryType {IndustryName = "Medical Supply Company", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedBy = 1, ModifiedBy = 1 });
                context.SaveChanges();
            }
            #endregion

            #region Country
            if (!context.Countries.Any())
            {
                context.Countries.AddRange(new Country { CountryName = "Afghanistan" });
                context.Countries.AddRange(new Country { CountryName = "Albania" });
                context.Countries.AddRange(new Country { CountryName = "Algeria" });
                context.Countries.AddRange(new Country { CountryName = "Andorra" });
                context.Countries.AddRange(new Country { CountryName = "Angola" });
                context.Countries.AddRange(new Country { CountryName = "Antigua and Barbuda" });
                context.Countries.AddRange(new Country { CountryName = "Argentina" });
                context.Countries.AddRange(new Country { CountryName = "Armenia" });
                context.Countries.AddRange(new Country { CountryName = "Australia" });
                context.Countries.AddRange(new Country { CountryName = "Austria" });
                context.Countries.AddRange(new Country { CountryName = "Azerbaijan" });
                context.Countries.AddRange(new Country { CountryName = "Bahamas" });
                context.Countries.AddRange(new Country { CountryName = "Bahrain" });
                context.Countries.AddRange(new Country { CountryName = "Bangladesh" });
                context.Countries.AddRange(new Country { CountryName = "Barbados" });
                context.Countries.AddRange(new Country { CountryName = "Belarus" });
                context.Countries.AddRange(new Country { CountryName = "Belgium" });
                context.Countries.AddRange(new Country { CountryName = "Belize" });
                context.Countries.AddRange(new Country { CountryName = "Benin" });
                context.Countries.AddRange(new Country { CountryName = "Bhutan" });
                context.Countries.AddRange(new Country { CountryName = "Bolivia" });
                context.Countries.AddRange(new Country { CountryName = "Bosnia and Herzegovina" });
                context.Countries.AddRange(new Country { CountryName = "Botswana" });
                context.Countries.AddRange(new Country { CountryName = "Brazil" });
                context.Countries.AddRange(new Country { CountryName = "Brunei" });
                context.Countries.AddRange(new Country { CountryName = "Bulgaria" });
                context.Countries.AddRange(new Country { CountryName = "Burkina Faso" });
                context.Countries.AddRange(new Country { CountryName = "Burundi" });
                context.Countries.AddRange(new Country { CountryName = "Cabo Verde" });
                context.Countries.AddRange(new Country { CountryName = "Cambodia" });
                context.Countries.AddRange(new Country { CountryName = "Cameroon" });
                context.Countries.AddRange(new Country { CountryName = "Canada" });
                context.Countries.AddRange(new Country { CountryName = "Central African Republic" });
                context.Countries.AddRange(new Country { CountryName = "Chad" });
                context.Countries.AddRange(new Country { CountryName = "Chile" });
                context.Countries.AddRange(new Country { CountryName = "China" });
                context.Countries.AddRange(new Country { CountryName = "Colombia" });
                context.Countries.AddRange(new Country { CountryName = "Comoros" });
                context.Countries.AddRange(new Country { CountryName = "Congo" });
                context.Countries.AddRange(new Country { CountryName = "Costa Rica" });
                context.Countries.AddRange(new Country { CountryName = "Croatia" });
                context.Countries.AddRange(new Country { CountryName = "Cuba" });
                context.Countries.AddRange(new Country { CountryName = "Cyprus" });
                context.Countries.AddRange(new Country { CountryName = "Czechia" });
                context.Countries.AddRange(new Country { CountryName = "Denmark" });
                context.Countries.AddRange(new Country { CountryName = "Djibouti" });
                context.Countries.AddRange(new Country { CountryName = "Dominica" });
                context.Countries.AddRange(new Country { CountryName = "Dominican Republic" });
                context.Countries.AddRange(new Country { CountryName = "East Timor" });
                context.Countries.AddRange(new Country { CountryName = "Ecuador" });
                context.Countries.AddRange(new Country { CountryName = "Egypt" });
                context.Countries.AddRange(new Country { CountryName = "El Salvador" });
                context.Countries.AddRange(new Country { CountryName = "Equatorial Guinea" });
                context.Countries.AddRange(new Country { CountryName = "Eritrea" });
                context.Countries.AddRange(new Country { CountryName = "Estonia" });
                context.Countries.AddRange(new Country { CountryName = "Eswatini" });
                context.Countries.AddRange(new Country { CountryName = "Ethiopia" });
                context.Countries.AddRange(new Country { CountryName = "Fiji" });
                context.Countries.AddRange(new Country { CountryName = "Finland" });
                context.Countries.AddRange(new Country { CountryName = "France" });
                context.Countries.AddRange(new Country { CountryName = "Gabon" });
                context.Countries.AddRange(new Country { CountryName = "Gambia" });
                context.Countries.AddRange(new Country { CountryName = "Georgia" });
                context.Countries.AddRange(new Country { CountryName = "Germany" });
                context.Countries.AddRange(new Country { CountryName = "Ghana" });
                context.Countries.AddRange(new Country { CountryName = "Greece" });
                context.Countries.AddRange(new Country { CountryName = "Grenada" });
                context.Countries.AddRange(new Country { CountryName = "Guatemala" });
                context.Countries.AddRange(new Country { CountryName = "Guinea" });
                context.Countries.AddRange(new Country { CountryName = "Guinea-Bissau" });
                context.Countries.AddRange(new Country { CountryName = "Guyana" });
                context.Countries.AddRange(new Country { CountryName = "Haiti" });
                context.Countries.AddRange(new Country { CountryName = "Honduras" });
                context.Countries.AddRange(new Country { CountryName = "Hungary" });
                context.Countries.AddRange(new Country { CountryName = "Iceland" });
                context.Countries.AddRange(new Country { CountryName = "India" });
                context.Countries.AddRange(new Country { CountryName = "Indonesia" });
                context.Countries.AddRange(new Country { CountryName = "Iran" });
                context.Countries.AddRange(new Country { CountryName = "Iraq" });
                context.Countries.AddRange(new Country { CountryName = "Ireland" });
                context.Countries.AddRange(new Country { CountryName = "Israel" });
                context.Countries.AddRange(new Country { CountryName = "Italy" });
                context.Countries.AddRange(new Country { CountryName = "Ivory Coast" });
                context.Countries.AddRange(new Country { CountryName = "Jamaica" });
                context.Countries.AddRange(new Country { CountryName = "Japan" });
                context.Countries.AddRange(new Country { CountryName = "Jordan" });
                context.Countries.AddRange(new Country { CountryName = "Kazakhstan" });
                context.Countries.AddRange(new Country { CountryName = "Kenya" });
                context.Countries.AddRange(new Country { CountryName = "Kiribati" });
                context.Countries.AddRange(new Country { CountryName = "Kosovo" });
                context.Countries.AddRange(new Country { CountryName = "Kuwait" });
                context.Countries.AddRange(new Country { CountryName = "Kyrgyzstan" });
                context.Countries.AddRange(new Country { CountryName = "Laos" });
                context.Countries.AddRange(new Country { CountryName = "Latvia" });
                context.Countries.AddRange(new Country { CountryName = "Lebanon" });
                context.Countries.AddRange(new Country { CountryName = "Lesotho" });
                context.Countries.AddRange(new Country { CountryName = "Liberia" });
                context.Countries.AddRange(new Country { CountryName = "Libya" });
                context.Countries.AddRange(new Country { CountryName = "Liechtenstein" });
                context.Countries.AddRange(new Country { CountryName = "Lithuania" });
                context.Countries.AddRange(new Country { CountryName = "Luxembourg" });
                context.Countries.AddRange(new Country { CountryName = "Madagascar" });
                context.Countries.AddRange(new Country { CountryName = "Malawi" });
                context.Countries.AddRange(new Country { CountryName = "Malaysia" });
                context.Countries.AddRange(new Country { CountryName = "Maldives" });
                context.Countries.AddRange(new Country { CountryName = "Mali" });
                context.Countries.AddRange(new Country { CountryName = "Malta" });
                context.Countries.AddRange(new Country { CountryName = "Marshall Islands" });
                context.Countries.AddRange(new Country { CountryName = "Mauritania" });
                context.Countries.AddRange(new Country { CountryName = "Mauritius" });
                context.Countries.AddRange(new Country { CountryName = "Mexico" });
                context.Countries.AddRange(new Country { CountryName = "Micronesia" });
                context.Countries.AddRange(new Country { CountryName = "Moldova" });
                context.Countries.AddRange(new Country { CountryName = "Monaco" });
                context.Countries.AddRange(new Country { CountryName = "Mongolia" });
                context.Countries.AddRange(new Country { CountryName = "Montenegro" });
                context.Countries.AddRange(new Country { CountryName = "Morocco" });
                context.Countries.AddRange(new Country { CountryName = "Mozambique" });
                context.Countries.AddRange(new Country { CountryName = "Myanmar" });
                context.Countries.AddRange(new Country { CountryName = "Namibia" });
                context.Countries.AddRange(new Country { CountryName = "Nauru" });
                context.Countries.AddRange(new Country { CountryName = "Nepal" });
                context.Countries.AddRange(new Country { CountryName = "Netherlands" });
                context.Countries.AddRange(new Country { CountryName = "New Zealand" });
                context.Countries.AddRange(new Country { CountryName = "Nicaragua" });
                context.Countries.AddRange(new Country { CountryName = "Niger" });
                context.Countries.AddRange(new Country { CountryName = "Nigeria" });
                context.Countries.AddRange(new Country { CountryName = "North Korea" });
                context.Countries.AddRange(new Country { CountryName = "North Macedonia" });
                context.Countries.AddRange(new Country { CountryName = "Norway" });
                context.Countries.AddRange(new Country { CountryName = "Oman" });
                context.Countries.AddRange(new Country { CountryName = "Pakistan" });
                context.Countries.AddRange(new Country { CountryName = "Palau" });
                context.Countries.AddRange(new Country { CountryName = "Palestine" });
                context.Countries.AddRange(new Country { CountryName = "Panama" });
                context.Countries.AddRange(new Country { CountryName = "Papua New Guinea" });
                context.Countries.AddRange(new Country { CountryName = "Paraguay" });
                context.Countries.AddRange(new Country { CountryName = "Peru" });
                context.Countries.AddRange(new Country { CountryName = "Philippines" });
                context.Countries.AddRange(new Country { CountryName = "Poland" });
                context.Countries.AddRange(new Country { CountryName = "Portugal" });
                context.Countries.AddRange(new Country { CountryName = "Qatar" });
                context.Countries.AddRange(new Country { CountryName = "Romania" });
                context.Countries.AddRange(new Country { CountryName = "Russia" });
                context.Countries.AddRange(new Country { CountryName = "Rwanda" });
                context.Countries.AddRange(new Country { CountryName = "Saint Kitts and Nevis" });
                context.Countries.AddRange(new Country { CountryName = "Saint Lucia" });
                context.Countries.AddRange(new Country { CountryName = "Saint Vincent and the Grenadines" });
                context.Countries.AddRange(new Country { CountryName = "Samoa" });
                context.Countries.AddRange(new Country { CountryName = "San Marino" });
                context.Countries.AddRange(new Country { CountryName = "Sao Tome and Principe" });
                context.Countries.AddRange(new Country { CountryName = "Saudi Arabia" });
                context.Countries.AddRange(new Country { CountryName = "Senegal" });
                context.Countries.AddRange(new Country { CountryName = "Serbia" });
                context.Countries.AddRange(new Country { CountryName = "Seychelles" });
                context.Countries.AddRange(new Country { CountryName = "Sierra Leone" });
                context.Countries.AddRange(new Country { CountryName = "Singapore" });
                context.Countries.AddRange(new Country { CountryName = "Slovakia" });
                context.Countries.AddRange(new Country { CountryName = "Slovenia" });
                context.Countries.AddRange(new Country { CountryName = "Solomon Islands" });
                context.Countries.AddRange(new Country { CountryName = "Somalia" });
                context.Countries.AddRange(new Country { CountryName = "South Africa" });
                context.Countries.AddRange(new Country { CountryName = "South Korea" });
                context.Countries.AddRange(new Country { CountryName = "South Sudan" });
                context.Countries.AddRange(new Country { CountryName = "Spain" });
                context.Countries.AddRange(new Country { CountryName = "Sri Lanka" });
                context.Countries.AddRange(new Country { CountryName = "Sudan" });
                context.Countries.AddRange(new Country { CountryName = "Suriname" });
                context.Countries.AddRange(new Country { CountryName = "Sweden" });
                context.Countries.AddRange(new Country { CountryName = "Switzerland" });
                context.Countries.AddRange(new Country { CountryName = "Syria" });
                context.Countries.AddRange(new Country { CountryName = "Taiwan" });
                context.Countries.AddRange(new Country { CountryName = "Tajikistan" });
                context.Countries.AddRange(new Country { CountryName = "Tanzania" });
                context.Countries.AddRange(new Country { CountryName = "Thailand" });
                context.Countries.AddRange(new Country { CountryName = "Togo" });
                context.Countries.AddRange(new Country { CountryName = "Tonga" });
                context.Countries.AddRange(new Country { CountryName = "Trinidad and Tobago" });
                context.Countries.AddRange(new Country { CountryName = "Tunisia" });
                context.Countries.AddRange(new Country { CountryName = "Turkey" });
                context.Countries.AddRange(new Country { CountryName = "Turkmenistan" });
                context.Countries.AddRange(new Country { CountryName = "Tuvalu" });
                context.Countries.AddRange(new Country { CountryName = "Uganda" });
                context.Countries.AddRange(new Country { CountryName = "Ukraine" });
                context.Countries.AddRange(new Country { CountryName = "United Arab Emirates" });
                context.Countries.AddRange(new Country { CountryName = "United Kingdom" });
                context.Countries.AddRange(new Country { CountryName = "United States" });
                context.Countries.AddRange(new Country { CountryName = "Uruguay" });
                context.Countries.AddRange(new Country { CountryName = "Uzbekistan" });
                context.Countries.AddRange(new Country { CountryName = "Vanuatu" });
                context.Countries.AddRange(new Country { CountryName = "Vatican City" });
                context.Countries.AddRange(new Country { CountryName = "Venezuela" });
                context.Countries.AddRange(new Country { CountryName = "Vietnam" });
                context.Countries.AddRange(new Country { CountryName = "Yemen" });
                context.Countries.AddRange(new Country { CountryName = "Zambia" });
                context.Countries.AddRange(new Country { CountryName = "Zimbabwe" });
                context.SaveChanges();
            }
            #endregion

            #region States
            if (!context.States.Any())
            {
                // States for Afghanistan (Line 1)
                context.States.AddRange(new State { StateName = "Kabul", CountryId = 1 });
                context.States.AddRange(new State { StateName = "Herat", CountryId = 1 });

                // States for Albania (Line 2)
                context.States.AddRange(new State { StateName = "Tirana", CountryId = 2 });
                context.States.AddRange(new State { StateName = "Durrës", CountryId = 2 });

                // States for Algeria (Line 3)
                context.States.AddRange(new State { StateName = "Algiers", CountryId = 3 });
                context.States.AddRange(new State { StateName = "Oran", CountryId = 3 });

                // States for Andorra (Line 4)
                context.States.AddRange(new State { StateName = "Andorra la Vella", CountryId = 4 });
                context.States.AddRange(new State { StateName = "Escaldes-Engordany", CountryId = 4 });

                // States for Angola (Line 5)
                context.States.AddRange(new State { StateName = "Luanda", CountryId = 5 });
                context.States.AddRange(new State { StateName = "Huambo", CountryId = 5 });

                // States for Antigua and Barbuda (Line 6)
                context.States.AddRange(new State { StateName = "Saint John's", CountryId = 6 });
                context.States.AddRange(new State { StateName = "Barbuda", CountryId = 6 });

                // States for Argentina (Line 7)
                context.States.AddRange(new State { StateName = "Buenos Aires", CountryId = 7 });
                context.States.AddRange(new State { StateName = "Córdoba", CountryId = 7 });

                // States for Armenia (Line 8)
                context.States.AddRange(new State { StateName = "Yerevan", CountryId = 8 });
                context.States.AddRange(new State { StateName = "Gyumri", CountryId = 8 });

                // States for Australia (Line 9)
                context.States.AddRange(new State { StateName = "New South Wales", CountryId = 9 });
                context.States.AddRange(new State { StateName = "Victoria", CountryId = 9 });

                // States for Austria (Line 10)
                context.States.AddRange(new State { StateName = "Vienna", CountryId = 10 });
                context.States.AddRange(new State { StateName = "Salzburg", CountryId = 10 });

                // States for Azerbaijan (Line 11)
                context.States.AddRange(new State { StateName = "Baku", CountryId = 11 });
                context.States.AddRange(new State { StateName = "Ganja", CountryId = 11 });

                // States for Bahamas (Line 12)
                context.States.AddRange(new State { StateName = "Nassau", CountryId = 12 });
                context.States.AddRange(new State { StateName = "Freeport", CountryId = 12 });

                // States for Bahrain (Line 13)
                context.States.AddRange(new State { StateName = "Capital Governorate", CountryId = 13 });
                context.States.AddRange(new State { StateName = "Muharraq Governorate", CountryId = 13 });

                // States for Bangladesh (Line 14)
                context.States.AddRange(new State { StateName = "Dhaka", CountryId = 14 });
                context.States.AddRange(new State { StateName = "Chittagong", CountryId = 14 });

                // States for Barbados (Line 15)
                context.States.AddRange(new State { StateName = "Saint Michael", CountryId = 15 });
                context.States.AddRange(new State { StateName = "Christ Church", CountryId = 15 });

                // States for Belarus (Line 16)
                context.States.AddRange(new State { StateName = "Minsk Region", CountryId = 16 });
                context.States.AddRange(new State { StateName = "Gomel Region", CountryId = 16 });

                // States for Belgium (Line 17)
                context.States.AddRange(new State { StateName = "Flanders", CountryId = 17 });
                context.States.AddRange(new State { StateName = "Wallonia", CountryId = 17 });

                // States for Belize (Line 18)
                context.States.AddRange(new State { StateName = "Belize District", CountryId = 18 });
                context.States.AddRange(new State { StateName = "Cayo District", CountryId = 18 });

                // States for Benin (Line 19)
                context.States.AddRange(new State { StateName = "Littoral", CountryId = 19 });
                context.States.AddRange(new State { StateName = "Atlantique", CountryId = 19 });

                // States for Bhutan (Line 20)
                context.States.AddRange(new State { StateName = "Thimphu", CountryId = 20 });
                context.States.AddRange(new State { StateName = "Punakha", CountryId = 20 });

                // States for Bolivia (Line 21)
                context.States.AddRange(new State { StateName = "La Paz", CountryId = 21 });
                context.States.AddRange(new State { StateName = "Santa Cruz", CountryId = 21 });

                // States for Bosnia and Herzegovina (Line 22)
                context.States.AddRange(new State { StateName = "Federation of Bosnia and Herzegovina", CountryId = 22 });
                context.States.AddRange(new State { StateName = "Republika Srpska", CountryId = 22 });

                // States for Botswana (Line 23)
                context.States.AddRange(new State { StateName = "Gaborone", CountryId = 23 });
                context.States.AddRange(new State { StateName = "Francistown", CountryId = 23 });

                // States for Brazil (Line 24)
                context.States.AddRange(new State { StateName = "São Paulo", CountryId = 24 });
                context.States.AddRange(new State { StateName = "Rio de Janeiro", CountryId = 24 });

                // States for Brunei (Line 25)
                context.States.AddRange(new State { StateName = "Brunei-Muara", CountryId = 25 });
                context.States.AddRange(new State { StateName = "Tutong", CountryId = 25 });

                // States for Bulgaria (Line 26)
                context.States.AddRange(new State { StateName = "Sofia", CountryId = 26 });
                context.States.AddRange(new State { StateName = "Plovdiv", CountryId = 26 });

                // States for Burkina Faso (Line 27)
                context.States.AddRange(new State { StateName = "Centre", CountryId = 27 });
                context.States.AddRange(new State { StateName = "Hauts-Bassins", CountryId = 27 });

                // States for Burundi (Line 28)
                context.States.AddRange(new State { StateName = "Bujumbura Mairie", CountryId = 28 });
                context.States.AddRange(new State { StateName = "Gitega", CountryId = 28 });

                // States for Cabo Verde (Line 29)
                context.States.AddRange(new State { StateName = "Santiago", CountryId = 29 });
                context.States.AddRange(new State { StateName = "São Vicente", CountryId = 29 });

                // States for Cambodia (Line 30)
                context.States.AddRange(new State { StateName = "Phnom Penh", CountryId = 30 });
                context.States.AddRange(new State { StateName = "Siem Reap", CountryId = 30 });

                // States for Cameroon (Line 31)
                context.States.AddRange(new State { StateName = "Centre", CountryId = 31 });
                context.States.AddRange(new State { StateName = "Littoral", CountryId = 31 });

                // States for Canada (Line 32)
                context.States.AddRange(new State { StateName = "Ontario", CountryId = 32 });
                context.States.AddRange(new State { StateName = "Quebec", CountryId = 32 });

                // States for Central African Republic (Line 33)
                context.States.AddRange(new State { StateName = "Bangui", CountryId = 33 });
                context.States.AddRange(new State { StateName = "Bamingui-Bangoran", CountryId = 33 });

                // States for Chad (Line 34)
                context.States.AddRange(new State { StateName = "N'Djamena", CountryId = 34 });
                context.States.AddRange(new State { StateName = "Hadjer-Lamis", CountryId = 34 });

                // States for Chile (Line 35)
                context.States.AddRange(new State { StateName = "Santiago Metropolitan", CountryId = 35 });
                context.States.AddRange(new State { StateName = "Valparaíso", CountryId = 35 });

                // States for China (Line 36)
                context.States.AddRange(new State { StateName = "Guangdong", CountryId = 36 });
                context.States.AddRange(new State { StateName = "Shandong", CountryId = 36 });

                // States for Colombia (Line 37)
                context.States.AddRange(new State { StateName = "Cundinamarca", CountryId = 37 });
                context.States.AddRange(new State { StateName = "Antioquia", CountryId = 37 });

                // States for Comoros (Line 38)
                context.States.AddRange(new State { StateName = "Grande Comore", CountryId = 38 });
                context.States.AddRange(new State { StateName = "Anjouan", CountryId = 38 });

                // States for Congo (Brazzaville) (Line 39)
                context.States.AddRange(new State { StateName = "Brazzaville", CountryId = 39 });
                context.States.AddRange(new State { StateName = "Pointe-Noire", CountryId = 39 });

                // States for Costa Rica (Line 41)
                context.States.AddRange(new State { StateName = "San José", CountryId = 40 });
                context.States.AddRange(new State { StateName = "Alajuela", CountryId = 40 });

                // States for Croatia (Line 43)
                context.States.AddRange(new State { StateName = "Zagreb", CountryId = 41 });
                context.States.AddRange(new State { StateName = "Split-Dalmatia", CountryId = 41 });

                // States for Cuba (Line 44)
                context.States.AddRange(new State { StateName = "Havana", CountryId = 42 });
                context.States.AddRange(new State { StateName = "Santiago de Cuba", CountryId = 42 });

                // States for Cyprus (Line 45)
                context.States.AddRange(new State { StateName = "Nicosia", CountryId = 43 });
                context.States.AddRange(new State { StateName = "Limassol", CountryId = 43 });

                // States for Czech Republic (Line 46)
                context.States.AddRange(new State { StateName = "Prague", CountryId = 44 });
                context.States.AddRange(new State { StateName = "Central Bohemia", CountryId = 44 });

                // States for Denmark (Line 47)
                context.States.AddRange(new State { StateName = "Capital Region of Denmark", CountryId = 45 });
                context.States.AddRange(new State { StateName = "Region of Southern Denmark", CountryId = 45 });

                // States for Djibouti (Line 48)
                context.States.AddRange(new State { StateName = "Djibouti City", CountryId = 46 });
                context.States.AddRange(new State { StateName = "Ali Sabieh", CountryId = 46 });

                // States for Dominica (Line 49)
                context.States.AddRange(new State { StateName = "Saint Andrew Parish", CountryId = 47 });
                context.States.AddRange(new State { StateName = "Saint David Parish", CountryId = 47 });

                // States for Dominican Republic (Line 50)
                context.States.AddRange(new State { StateName = "Santo Domingo", CountryId = 48 });
                context.States.AddRange(new State { StateName = "Santiago", CountryId = 48 });

                // States for East Timor (Timor-Leste) (Line 51)
                context.States.AddRange(new State { StateName = "Dili", CountryId = 49 });
                context.States.AddRange(new State { StateName = "Baucau", CountryId = 49 });

                // States for Ecuador (Line 52)
                context.States.AddRange(new State { StateName = "Pichincha", CountryId = 50 });
                context.States.AddRange(new State { StateName = "Guayas", CountryId = 50 });

                // States for Egypt (Line 53)
                context.States.AddRange(new State { StateName = "Cairo", CountryId = 51 });
                context.States.AddRange(new State { StateName = "Alexandria", CountryId = 51 });

                // States for El Salvador (Line 54)
                context.States.AddRange(new State { StateName = "San Salvador", CountryId = 52 });
                context.States.AddRange(new State { StateName = "Santa Ana", CountryId = 52 });

                // States for Equatorial Guinea (Line 55)
                context.States.AddRange(new State { StateName = "Litoral", CountryId = 53 });
                context.States.AddRange(new State { StateName = "Bioko Norte", CountryId = 53 });

                // States for Eritrea (Line 56)
                context.States.AddRange(new State { StateName = "Maekel", CountryId = 54 });
                context.States.AddRange(new State { StateName = "Debub", CountryId = 54 });

                // States for Estonia (Line 57)
                context.States.AddRange(new State { StateName = "Harju County", CountryId = 55 });
                context.States.AddRange(new State { StateName = "Tartu County", CountryId = 55 });

                // States for Eswatini (Line 58)
                context.States.AddRange(new State { StateName = "Hhohho", CountryId = 56 });
                context.States.AddRange(new State { StateName = "Manzini", CountryId = 56 });

                // States for Ethiopia (Line 59)
                context.States.AddRange(new State { StateName = "Addis Ababa", CountryId = 57 });
                context.States.AddRange(new State { StateName = "Oromia", CountryId = 57 });

                // States for Fiji (Line 60)
                context.States.AddRange(new State { StateName = "Central Division", CountryId = 58 });
                context.States.AddRange(new State { StateName = "Western Division", CountryId = 58 });

                // States for Finland (Line 61)
                context.States.AddRange(new State { StateName = "Uusimaa", CountryId = 59 });
                context.States.AddRange(new State { StateName = "Pirkanmaa", CountryId = 59 });

                // States for France (Line 62)
                context.States.AddRange(new State { StateName = "Île-de-France", CountryId = 60 });
                context.States.AddRange(new State { StateName = "Auvergne-Rhône-Alpes", CountryId = 60 });

                // States for Gabon (Line 63)
                context.States.AddRange(new State { StateName = "Estuaire", CountryId = 61 });
                context.States.AddRange(new State { StateName = "Haut-Ogooué", CountryId = 61 });

                // States for Gambia (Line 64)
                context.States.AddRange(new State { StateName = "Banjul", CountryId = 62 });
                context.States.AddRange(new State { StateName = "Upper River", CountryId = 62 });

                // States for Georgia (Line 65)
                context.States.AddRange(new State { StateName = "Tbilisi", CountryId = 63 });
                context.States.AddRange(new State { StateName = "Kakheti", CountryId = 63 });

                // States for Germany (Line 66)
                context.States.AddRange(new State { StateName = "North Rhine-Westphalia", CountryId = 64 });
                context.States.AddRange(new State { StateName = "Bavaria", CountryId = 64 });

                // States for Ghana (Line 67)
                context.States.AddRange(new State { StateName = "Greater Accra", CountryId = 65 });
                context.States.AddRange(new State { StateName = "Ashanti", CountryId = 65 });

                // States for Greece (Line 68)
                context.States.AddRange(new State { StateName = "Attica", CountryId = 66 });
                context.States.AddRange(new State { StateName = "Central Macedonia", CountryId = 66 });

                // States for Grenada (Line 69)
                context.States.AddRange(new State { StateName = "Saint George", CountryId = 67 });
                context.States.AddRange(new State { StateName = "Saint Andrew", CountryId = 67 });

                // States for Guatemala (Line 70)
                context.States.AddRange(new State { StateName = "Guatemala Department", CountryId = 68 });
                context.States.AddRange(new State { StateName = "Quetzaltenango", CountryId = 68 });

                // States for Guinea (Line 71)
                context.States.AddRange(new State { StateName = "Conakry", CountryId = 69 });
                context.States.AddRange(new State { StateName = "Labe", CountryId = 69 });

                // States for Guinea-Bissau (Line 72)
                context.States.AddRange(new State { StateName = "Bissau", CountryId = 70 });
                context.States.AddRange(new State { StateName = "Bolama", CountryId = 70 });

                // States for Guyana (Line 73)
                context.States.AddRange(new State { StateName = "Demerara-Mahaica", CountryId = 71 });
                context.States.AddRange(new State { StateName = "Essequibo Islands-West Demerara", CountryId = 71 });

                // States for Haiti (Line 74)
                context.States.AddRange(new State { StateName = "Ouest", CountryId = 72 });
                context.States.AddRange(new State { StateName = "Nord", CountryId = 72 });

                // States for Honduras (Line 75)
                context.States.AddRange(new State { StateName = "Francisco Morazán", CountryId = 73 });
                context.States.AddRange(new State { StateName = "Cortés", CountryId = 73 });


                // States for Hungary (Line 77)
                context.States.AddRange(new State { StateName = "Budapest", CountryId = 74 });
                context.States.AddRange(new State { StateName = "Pest County", CountryId = 74 });

                // States for Iceland (Line 78)
                context.States.AddRange(new State { StateName = "Capital Region", CountryId = 75 });
                context.States.AddRange(new State { StateName = "Southern Peninsula", CountryId = 75 });

                // States for Indonesia (Line 77)
                context.States.AddRange(new State { StateName = "West Java", CountryId = 77 });
                context.States.AddRange(new State { StateName = "East Java", CountryId = 77 });

                // States for Iran (Line 78)
                context.States.AddRange(new State { StateName = "Tehran", CountryId = 78 });
                context.States.AddRange(new State { StateName = "Isfahan", CountryId = 78 });

                // States for Iraq (Line 79)
                context.States.AddRange(new State { StateName = "Baghdad", CountryId = 79 });
                context.States.AddRange(new State { StateName = "Nineveh", CountryId = 79 });

                // States for Ireland (Line 80)
                context.States.AddRange(new State { StateName = "Leinster", CountryId = 80 });
                context.States.AddRange(new State { StateName = "Munster", CountryId = 80 });

                // States for Israel (Line 81)
                context.States.AddRange(new State { StateName = "Tel Aviv District", CountryId = 81 });
                context.States.AddRange(new State { StateName = "Jerusalem District", CountryId = 81 });

                // States for Italy (Line 82)
                context.States.AddRange(new State { StateName = "Lazio", CountryId = 82 });
                context.States.AddRange(new State { StateName = "Lombardy", CountryId = 82 });

                // States for Jamaica (Line 83)
                context.States.AddRange(new State { StateName = "Kingston", CountryId = 83 });
                context.States.AddRange(new State { StateName = "Saint Andrew", CountryId = 83 });

                // States for Japan (Line 84)
                context.States.AddRange(new State { StateName = "Tokyo", CountryId = 84 });
                context.States.AddRange(new State { StateName = "Osaka", CountryId = 84 });

                // States for Jordan (Line 85)
                context.States.AddRange(new State { StateName = "Amman", CountryId = 85 });
                context.States.AddRange(new State { StateName = "Irbid", CountryId = 85 });

                // States for Kazakhstan (Line 86)
                context.States.AddRange(new State { StateName = "Almaty", CountryId = 86 });
                context.States.AddRange(new State { StateName = "Nur-Sultan", CountryId = 86 });

                // States for Kenya (Line 87)
                context.States.AddRange(new State { StateName = "Nairobi", CountryId = 87 });
                context.States.AddRange(new State { StateName = "Mombasa", CountryId = 87 });

                // States for Kiribati (Line 88)
                context.States.AddRange(new State { StateName = "Gilbert Islands", CountryId = 88 });
                context.States.AddRange(new State { StateName = "Line Islands", CountryId = 88 });

                // States for Kosovo (Line 89)
                context.States.AddRange(new State { StateName = "Pristina", CountryId = 89 });
                context.States.AddRange(new State { StateName = "Prizren", CountryId = 89 });

                // States for Kuwait (Line 90)
                context.States.AddRange(new State { StateName = "Al Asimah", CountryId = 90 });
                context.States.AddRange(new State { StateName = "Hawalli", CountryId = 90 });

                // States for Kyrgyzstan (Line 91)
                context.States.AddRange(new State { StateName = "Chuy Region", CountryId = 91 });
                context.States.AddRange(new State { StateName = "Osh Region", CountryId = 91 });

                // States for Laos (Line 92)
                context.States.AddRange(new State { StateName = "Vientiane Prefecture", CountryId = 92 });
                context.States.AddRange(new State { StateName = "Savannakhet", CountryId = 92 });

                // States for Latvia (Line 93)
                context.States.AddRange(new State { StateName = "Riga", CountryId = 93 });
                context.States.AddRange(new State { StateName = "Daugavpils", CountryId = 93 });

                // States for Lebanon (Line 94)
                context.States.AddRange(new State { StateName = "Mount Lebanon Governorate", CountryId = 94 });
                context.States.AddRange(new State { StateName = "Beirut Governorate", CountryId = 94 });

                // States for Lesotho (Line 95)
                context.States.AddRange(new State { StateName = "Maseru", CountryId = 95 });
                context.States.AddRange(new State { StateName = "Mafeteng", CountryId = 95 });

                // States for Liberia (Line 96)
                context.States.AddRange(new State { StateName = "Montserrado", CountryId = 96 });
                context.States.AddRange(new State { StateName = "Nimba", CountryId = 96 });

                // States for Libya (Line 97)
                context.States.AddRange(new State { StateName = "Tripoli", CountryId = 97 });
                context.States.AddRange(new State { StateName = "Benghazi", CountryId = 97 });

                // States for Liechtenstein (Line 98)
                context.States.AddRange(new State { StateName = "Balzers", CountryId = 98 });
                context.States.AddRange(new State { StateName = "Vaduz", CountryId = 98 });

                // States for Lithuania (Line 99)
                context.States.AddRange(new State { StateName = "Vilnius", CountryId = 99 });
                context.States.AddRange(new State { StateName = "Kaunas", CountryId = 99 });

                // States for Luxembourg (Line 100)
                context.States.AddRange(new State { StateName = "Luxembourg District", CountryId = 100 });
                context.States.AddRange(new State { StateName = "Diekirch District", CountryId = 100 });

                // States for Madagascar (Line 101)
                context.States.AddRange(new State { StateName = "Analamanga", CountryId = 101 });
                context.States.AddRange(new State { StateName = "Atsinanana", CountryId = 101 });

                // States for Malawi (Line 102)
                context.States.AddRange(new State { StateName = "Central Region", CountryId = 102 });
                context.States.AddRange(new State { StateName = "Southern Region", CountryId = 102 });

                // States for Malaysia (Line 103)
                context.States.AddRange(new State { StateName = "Selangor", CountryId = 103 });
                context.States.AddRange(new State { StateName = "Johor", CountryId = 103 });

                // States for Maldives (Line 104)
                context.States.AddRange(new State { StateName = "Malé", CountryId = 104 });
                context.States.AddRange(new State { StateName = "Addu Atoll", CountryId = 104 });

                // States for Mali (Line 105)
                context.States.AddRange(new State { StateName = "Bamako", CountryId = 105 });
                context.States.AddRange(new State { StateName = "Kayes", CountryId = 105 });

                // States for Malta (Line 106)
                context.States.AddRange(new State { StateName = "Northern Region", CountryId = 106 });
                context.States.AddRange(new State { StateName = "Southern Region", CountryId = 106 });

                // States for Marshall Islands (Line 107)
                context.States.AddRange(new State { StateName = "Majuro Atoll", CountryId = 107 });
                context.States.AddRange(new State { StateName = "Kwajalein Atoll", CountryId = 107 });

                // States for Mauritania (Line 108)
                context.States.AddRange(new State { StateName = "Nouakchott", CountryId = 108 });
                context.States.AddRange(new State { StateName = "Guidimaka", CountryId = 108 });

                // States for Mauritius (Line 109)
                context.States.AddRange(new State { StateName = "Port Louis", CountryId = 109 });
                context.States.AddRange(new State { StateName = "Plaines Wilhems", CountryId = 109 });

                // States for Mexico (Line 110)
                context.States.AddRange(new State { StateName = "Mexico City", CountryId = 110 });
                context.States.AddRange(new State { StateName = "Jalisco", CountryId = 110 });

                // States for Micronesia (Line 111)
                context.States.AddRange(new State { StateName = "Pohnpei", CountryId = 111 });
                context.States.AddRange(new State { StateName = "Chuuk", CountryId = 111 });

                // States for Moldova (Line 112)
                context.States.AddRange(new State { StateName = "Chișinău", CountryId = 112 });
                context.States.AddRange(new State { StateName = "Tiraspol", CountryId = 112 });

                // States for Monaco (Line 113)
                context.States.AddRange(new State { StateName = "Monaco", CountryId = 113 });

                // States for Mongolia (Line 114)
                context.States.AddRange(new State { StateName = "Ulaanbaatar", CountryId = 114 });
                context.States.AddRange(new State { StateName = "Darkhan", CountryId = 114 });

                // States for Montenegro (Line 115)
                context.States.AddRange(new State { StateName = "Podgorica", CountryId = 115 });
                context.States.AddRange(new State { StateName = "Nikšić", CountryId = 115 });

                // States for Morocco (Line 116)
                context.States.AddRange(new State { StateName = "Casablanca-Settat", CountryId = 116 });
                context.States.AddRange(new State { StateName = "Fès-Meknès", CountryId = 116 });

                // States for Mozambique (Line 117)
                context.States.AddRange(new State { StateName = "Maputo City", CountryId = 117 });
                context.States.AddRange(new State { StateName = "Nampula", CountryId = 117 });

                // States for Myanmar (Line 118)
                context.States.AddRange(new State { StateName = "Yangon", CountryId = 118 });
                context.States.AddRange(new State { StateName = "Mandalay", CountryId = 118 });

                // States for Namibia (Line 119)
                context.States.AddRange(new State { StateName = "Khomas", CountryId = 119 });
                context.States.AddRange(new State { StateName = "Erongo", CountryId = 119 });

                // States for Nauru (Line 120)
                context.States.AddRange(new State { StateName = "Yaren", CountryId = 120 });

                // States for Nepal (Line 121)
                context.States.AddRange(new State { StateName = "Bagmati Pradesh", CountryId = 121 });
                context.States.AddRange(new State { StateName = "Gandaki Pradesh", CountryId = 121 });

                // States for Netherlands (Line 122)
                context.States.AddRange(new State { StateName = "North Holland", CountryId = 122 });
                context.States.AddRange(new State { StateName = "South Holland", CountryId = 122 });

                // States for New Zealand (Line 123)
                context.States.AddRange(new State { StateName = "Auckland Region", CountryId = 123 });
                context.States.AddRange(new State { StateName = "Canterbury Region", CountryId = 123 });

                // States for Nicaragua (Line 124)
                context.States.AddRange(new State { StateName = "Managua", CountryId = 124 });
                context.States.AddRange(new State { StateName = "León", CountryId = 124 });

                // States for Niger (Line 125)
                context.States.AddRange(new State { StateName = "Niamey", CountryId = 125 });
                context.States.AddRange(new State { StateName = "Tahoua", CountryId = 125 });

                // States for Nigeria (Line 126)
                context.States.AddRange(new State { StateName = "Lagos", CountryId = 126 });
                context.States.AddRange(new State { StateName = "Kano", CountryId = 126 });

                // States for North Korea (Line 127)
                context.States.AddRange(new State { StateName = "Pyongyang", CountryId = 127 });
                context.States.AddRange(new State { StateName = "Hamhung", CountryId = 127 });

                // States for North Macedonia (Line 128)
                context.States.AddRange(new State { StateName = "Skopje", CountryId = 128 });
                context.States.AddRange(new State { StateName = "Bitola", CountryId = 128 });

                // States for Norway (Line 129)
                context.States.AddRange(new State { StateName = "Oslo", CountryId = 129 });
                context.States.AddRange(new State { StateName = "Bergen", CountryId = 129 });

                // States for Oman (Line 130)
                context.States.AddRange(new State { StateName = "Muscat", CountryId = 130 });
                context.States.AddRange(new State { StateName = "Salalah", CountryId = 130 });

                // States for Pakistan (Line 131)
                context.States.AddRange(new State { StateName = "Punjab", CountryId = 131 });
                context.States.AddRange(new State { StateName = "Sindh", CountryId = 131 });

                // States for Palau (Line 132)
                context.States.AddRange(new State { StateName = "Ngerulmud", CountryId = 132 });
                context.States.AddRange(new State { StateName = "Koror", CountryId = 132 });

                // States for Palestine (Line 133)
                context.States.AddRange(new State { StateName = "West Bank", CountryId = 133 });
                context.States.AddRange(new State { StateName = "Gaza Strip", CountryId = 133 });

                // States for Panama (Line 134)
                context.States.AddRange(new State { StateName = "Panamá", CountryId = 134 });
                context.States.AddRange(new State { StateName = "Colón", CountryId = 134 });

                // States for Papua New Guinea (Line 135)
                context.States.AddRange(new State { StateName = "National Capital District", CountryId = 135 });
                context.States.AddRange(new State { StateName = "Morobe", CountryId = 135 });

                // States for Paraguay (Line 136)
                context.States.AddRange(new State { StateName = "Central Department", CountryId = 136 });
                context.States.AddRange(new State { StateName = "Ñeembucú", CountryId = 136 });

                // States for Peru (Line 137)
                context.States.AddRange(new State { StateName = "Lima", CountryId = 137 });
                context.States.AddRange(new State { StateName = "Cusco", CountryId = 137 });

                // States for Philippines (Line 138)
                context.States.AddRange(new State { StateName = "Metro Manila", CountryId = 138 });
                context.States.AddRange(new State { StateName = "Calabarzon", CountryId = 138 });

                // States for Poland (Line 139)
                context.States.AddRange(new State { StateName = "Masovian Voivodeship", CountryId = 139 });
                context.States.AddRange(new State { StateName = "Lesser Poland Voivodeship", CountryId = 139 });

                // States for Portugal (Line 140)
                context.States.AddRange(new State { StateName = "Lisbon", CountryId = 140 });
                context.States.AddRange(new State { StateName = "Porto", CountryId = 140 });

                // States for Qatar (Line 141)
                context.States.AddRange(new State { StateName = "Doha", CountryId = 141 });

                // States for Romania (Line 142)
                context.States.AddRange(new State { StateName = "Bucharest", CountryId = 142 });
                context.States.AddRange(new State { StateName = "Cluj-Napoca", CountryId = 142 });

                // States for Russia (Line 143)
                context.States.AddRange(new State { StateName = "Moscow", CountryId = 143 });
                context.States.AddRange(new State { StateName = "Saint Petersburg", CountryId = 143 });

                // States for Rwanda (Line 144)
                context.States.AddRange(new State { StateName = "Kigali", CountryId = 144 });
                context.States.AddRange(new State { StateName = "Eastern Province", CountryId = 144 });

                // States for Saint Kitts and Nevis (Line 145)
                context.States.AddRange(new State { StateName = "Saint George Basseterre Parish", CountryId = 145 });
                context.States.AddRange(new State { StateName = "Saint John Capisterre Parish", CountryId = 145 });

                // States for Saint Lucia (Line 146)
                context.States.AddRange(new State { StateName = "Castries", CountryId = 146 });
                context.States.AddRange(new State { StateName = "Gros Islet", CountryId = 146 });

                // States for Saint Vincent and the Grenadines (Line 147)
                context.States.AddRange(new State { StateName = "Saint George Parish", CountryId = 147 });
                context.States.AddRange(new State { StateName = "Charlotte Parish", CountryId = 147 });

                // States for Samoa (Line 148)
                context.States.AddRange(new State { StateName = "Tuamasaga", CountryId = 148 });
                context.States.AddRange(new State { StateName = "A'ana", CountryId = 148 });

                // States for San Marino (Line 149)
                context.States.AddRange(new State { StateName = "San Marino", CountryId = 149 });

                // States for São Tomé and Príncipe (Line 150)
                context.States.AddRange(new State { StateName = "São Tomé Province", CountryId = 150 });
                context.States.AddRange(new State { StateName = "Príncipe Province", CountryId = 150 });

                // States for Saudi Arabia (Line 151)
                context.States.AddRange(new State { StateName = "Riyadh", CountryId = 151 });
                context.States.AddRange(new State { StateName = "Mecca", CountryId = 151 });

                // States for Senegal (Line 152)
                context.States.AddRange(new State { StateName = "Dakar", CountryId = 152 });
                context.States.AddRange(new State { StateName = "Thiès", CountryId = 152 });

                // States for Serbia (Line 153)
                context.States.AddRange(new State { StateName = "Belgrade", CountryId = 153 });
                context.States.AddRange(new State { StateName = "Novi Sad", CountryId = 153 });

                // States for Seychelles (Line 154)
                context.States.AddRange(new State { StateName = "La Digue", CountryId = 154 });
                context.States.AddRange(new State { StateName = "Praslin", CountryId = 154 });

                // States for Sierra Leone (Line 155)
                context.States.AddRange(new State { StateName = "Western Area", CountryId = 155 });
                context.States.AddRange(new State { StateName = "Northern Province", CountryId = 155 });

                // States for Singapore (Line 156)
                context.States.AddRange(new State { StateName = "Central Region", CountryId = 156 });

                // States for Slovakia (Line 157)
                context.States.AddRange(new State { StateName = "Bratislava Region", CountryId = 157 });
                context.States.AddRange(new State { StateName = "Nitra Region", CountryId = 157 });

                // States for Slovenia (Line 158)
                context.States.AddRange(new State { StateName = "Ljubljana", CountryId = 158 });
                context.States.AddRange(new State { StateName = "Maribor", CountryId = 158 });

                // States for Solomon Islands (Line 159)
                context.States.AddRange(new State { StateName = "Guadalcanal Province", CountryId = 159 });
                context.States.AddRange(new State { StateName = "Malaita Province", CountryId = 159 });

                // States for Somalia (Line 160)
                context.States.AddRange(new State { StateName = "Banadir", CountryId = 160 });
                context.States.AddRange(new State { StateName = "Puntland", CountryId = 160 });

                // States for South Africa (Line 161)
                context.States.AddRange(new State { StateName = "Gauteng", CountryId = 161 });
                context.States.AddRange(new State { StateName = "KwaZulu-Natal", CountryId = 161 });

                // States for South Korea (Line 162)
                context.States.AddRange(new State { StateName = "Seoul", CountryId = 162 });
                context.States.AddRange(new State { StateName = "Busan", CountryId = 162 });

                // States for South Sudan (Line 163)
                context.States.AddRange(new State { StateName = "Central Equatoria", CountryId = 163 });
                context.States.AddRange(new State { StateName = "Northern Bahr el Ghazal", CountryId = 163 });

                // States for Spain (Line 164)
                context.States.AddRange(new State { StateName = "Community of Madrid", CountryId = 164 });
                context.States.AddRange(new State { StateName = "Catalonia", CountryId = 164 });

                // States for Sri Lanka (Line 165)
                context.States.AddRange(new State { StateName = "Western Province", CountryId = 165 });
                context.States.AddRange(new State { StateName = "Central Province", CountryId = 165 });

                // States for Sudan (Line 166)
                context.States.AddRange(new State { StateName = "Khartoum", CountryId = 166 });
                context.States.AddRange(new State { StateName = "Gezira", CountryId = 166 });

                // States for Suriname (Line 167)
                context.States.AddRange(new State { StateName = "Paramaribo", CountryId = 167 });
                context.States.AddRange(new State { StateName = "Nickerie", CountryId = 167 });

                // States for Sweden (Line 168)
                context.States.AddRange(new State { StateName = "Stockholm County", CountryId = 168 });
                context.States.AddRange(new State { StateName = "Västra Götaland County", CountryId = 168 });

                // States for Switzerland (Line 169)
                context.States.AddRange(new State { StateName = "Zürich", CountryId = 169 });
                context.States.AddRange(new State { StateName = "Geneva", CountryId = 169 });

                // States for Syria (Line 170)
                context.States.AddRange(new State { StateName = "Damascus", CountryId = 170 });
                context.States.AddRange(new State { StateName = "Aleppo", CountryId = 170 });

                // States for Taiwan (Line 171)
                context.States.AddRange(new State { StateName = "Taipei", CountryId = 171 });
                context.States.AddRange(new State { StateName = "New Taipei", CountryId = 171 });

                // States for Tajikistan (Line 172)
                context.States.AddRange(new State { StateName = "Districts of Republican Subordination", CountryId = 172 });
                context.States.AddRange(new State { StateName = "Khatlon Region", CountryId = 172 });

                // States for Tanzania (Line 173)
                context.States.AddRange(new State { StateName = "Dar es Salaam", CountryId = 173 });
                context.States.AddRange(new State { StateName = "Mwanza", CountryId = 173 });

                // States for Thailand (Line 174)
                context.States.AddRange(new State { StateName = "Bangkok", CountryId = 174 });
                context.States.AddRange(new State { StateName = "Chiang Mai", CountryId = 174 });

                // States for Timor-Leste (Line 175)
                context.States.AddRange(new State { StateName = "Dili", CountryId = 175 });

                // States for Togo (Line 176)
                context.States.AddRange(new State { StateName = "Maritime", CountryId = 176 });
                context.States.AddRange(new State { StateName = "Plateaux", CountryId = 176 });

                // States for Tonga (Line 177)
                context.States.AddRange(new State { StateName = "Tongatapu", CountryId = 177 });
                context.States.AddRange(new State { StateName = "Vava'u", CountryId = 177 });

                // States for Trinidad and Tobago (Line 178)
                context.States.AddRange(new State { StateName = "San Fernando", CountryId = 178 });
                context.States.AddRange(new State { StateName = "Chaguanas", CountryId = 178 });

                // States for Tunisia (Line 179)
                context.States.AddRange(new State { StateName = "Tunis", CountryId = 179 });
                context.States.AddRange(new State { StateName = "Sfax", CountryId = 179 });

                // States for Turkey (Line 180)
                context.States.AddRange(new State { StateName = "Istanbul", CountryId = 180 });
                context.States.AddRange(new State { StateName = "Ankara", CountryId = 180 });

                // States for Turkmenistan (Line 181)
                context.States.AddRange(new State { StateName = "Ahal Region", CountryId = 181 });
                context.States.AddRange(new State { StateName = "Balkan Region", CountryId = 181 });

                // States for Tuvalu (Line 182)
                context.States.AddRange(new State { StateName = "Funafuti", CountryId = 182 });

                // States for Uganda (Line 183)
                context.States.AddRange(new State { StateName = "Central Region", CountryId = 183 });
                context.States.AddRange(new State { StateName = "Eastern Region", CountryId = 183 });

                // States for Ukraine (Line 184)
                context.States.AddRange(new State { StateName = "Kyiv", CountryId = 184 });
                context.States.AddRange(new State { StateName = "Kharkiv", CountryId = 184 });

                // States for United Arab Emirates (Line 185)
                context.States.AddRange(new State { StateName = "Dubai", CountryId = 185 });
                context.States.AddRange(new State { StateName = "Abu Dhabi", CountryId = 185 });

                // States for United Kingdom (Line 186)
                context.States.AddRange(new State { StateName = "England", CountryId = 186 });
                context.States.AddRange(new State { StateName = "Scotland", CountryId = 186 });

                // States for United States (Line 187)
                context.States.AddRange(new State { StateName = "California", CountryId = 187 });
                context.States.AddRange(new State { StateName = "Texas", CountryId = 187 });

                // States for Uruguay (Line 188)
                context.States.AddRange(new State { StateName = "Montevideo", CountryId = 188 });
                context.States.AddRange(new State { StateName = "Canelones", CountryId = 188 });

                // States for Uzbekistan (Line 189)
                context.States.AddRange(new State { StateName = "Tashkent", CountryId = 189 });
                context.States.AddRange(new State { StateName = "Namangan", CountryId = 189 });

                // States for Vanuatu (Line 190)
                context.States.AddRange(new State { StateName = "Shefa", CountryId = 190 });
                context.States.AddRange(new State { StateName = "Tafea", CountryId = 190 });

                // States for Vatican City (Line 191)
                context.States.AddRange(new State { StateName = "Vatican City", CountryId = 191 });

                // States for Venezuela (Line 192)
                context.States.AddRange(new State { StateName = "Capital District", CountryId = 192 });
                context.States.AddRange(new State { StateName = "Zulia", CountryId = 192 });

                // States for Vietnam (Line 193)
                context.States.AddRange(new State { StateName = "Hanoi", CountryId = 193 });
                context.States.AddRange(new State { StateName = "Ho Chi Minh City", CountryId = 193 });

                // States for Yemen (Line 194)
                context.States.AddRange(new State { StateName = "Sana'a", CountryId = 194 });
                context.States.AddRange(new State { StateName = "Aden", CountryId = 194 });

                // States for Zambia (Line 195)
                context.States.AddRange(new State { StateName = "Lusaka", CountryId = 195 });
                context.States.AddRange(new State { StateName = "Copperbelt Province", CountryId = 195 });

                // States for Zimbabwe (Line 196)
                context.States.AddRange(new State { StateName = "Harare", CountryId = 196 });
                context.States.AddRange(new State { StateName = "Bulawayo", CountryId = 196 });

                //States for India
                context.States.AddRange(new State { StateName = "Andaman and Nicobar Islands", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Andhra Pradesh", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Arunachal Pradesh", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Assam", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Bihar", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Chandigarh", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Chhattisgarh", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Dadra and Nagar Haveli and Daman and Diu", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Delhi", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Goa", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Gujarat", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Haryana", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Himachal Pradesh", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Jammu and Kashmir", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Jharkhand", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Karnataka", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Kerala", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Ladakh", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Lakshadweep", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Madhya Pradesh", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Maharashtra", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Manipur", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Meghalaya", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Mizoram", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Nagaland", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Odisha", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Puducherry", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Punjab", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Rajasthan", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Sikkim", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Tamil Nadu", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Telangana", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Tripura", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Uttar Pradesh", CountryId = 76 });
                context.States.AddRange(new State { StateName = "Uttarakhand", CountryId = 76 });
                context.States.AddRange(new State { StateName = "West Bengal", CountryId = 76 });
                context.SaveChanges();
            }
            #endregion

            #region OrganizationDetails
            if (!context.OrganizationDetails.Any(o => o.OrganizationName == "Healink"))
            {
                context.OrganizationDetails.AddRange(new OrganizationDetail
                {
                    OrganizationName = "Healink",
                    OrganizationWebsite = "https://www.healink.com",
                    OrganizationSize = 1,
                    OrganizationLogo = "https://ai-studio-assets.limewire.media/u/280cced9-e893-4ce9-9a51-09c40c1a57c3/image/087eed58-a8b9-485b-b0ad-e6e09d34c177?Expires=1708276067&Signature=AkkS9EZ5x4wWlZwkMbC3pWwrYq26HdbpQ1HEMsBdeedq9xB4TgOCb8DTDmd3LJhgOSsJ7qrlMYwlqMlSYSHGRPc8YpCLf0f99ERm62FAWkbdi1Q00-o4qfMjgIyo0wDcRG~YuStnstgkvV06PHzbC4lJO7j4zMw6vQ86DEQog16gDJPEC24wfAf7TT1s3mdU9yIXECfEQYYre51OKfJprVMKo53MWkKNcVlNdEzXN9TmXdU-UNdk8Kz6fclhhOQ1TVVcChVjXwgm78DBsyXRUXuwXpvqVSBsFbrNhs3ZaPb2PxDpl9sxGFxS6UhUZMy7J1Wyn0pl8Dugsn4D~bD88A__&Key-Pair-Id=K1U52DHN9E92VT",
                    OrganizationBio = "Your Gateway to Professional Success and Connection! Elevate your career with Healink, the ultimate platform for healthcare professionals",
                    CountryId = 76,
                    StateId = 17,
                    Region = "Kochi",
                    OrganizationTypeId = 1,
                    FollowCount = 0,
                    TagLine = "Connecting Care, Empowering Careers.",
                    UserId = 2,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedBy = 1
                });
                context.SaveChanges();
            }
            #endregion

            #region UserDetails
            if (!context.UserDetails.Any())
            {
                context.UserDetails.AddRange(new UserDetail
                {
                    UserId = 1,
                    FirstName = "Super",
                    LastName = "User",
                    ProfileImage = "https://ai-studio-assets.limewire.media/u/280cced9-e893-4ce9-9a51-09c40c1a57c3/image/087eed58-a8b9-485b-b0ad-e6e09d34c177?Expires=1708276067&Signature=AkkS9EZ5x4wWlZwkMbC3pWwrYq26HdbpQ1HEMsBdeedq9xB4TgOCb8DTDmd3LJhgOSsJ7qrlMYwlqMlSYSHGRPc8YpCLf0f99ERm62FAWkbdi1Q00-o4qfMjgIyo0wDcRG~YuStnstgkvV06PHzbC4lJO7j4zMw6vQ86DEQog16gDJPEC24wfAf7TT1s3mdU9yIXECfEQYYre51OKfJprVMKo53MWkKNcVlNdEzXN9TmXdU-UNdk8Kz6fclhhOQ1TVVcChVjXwgm78DBsyXRUXuwXpvqVSBsFbrNhs3ZaPb2PxDpl9sxGFxS6UhUZMy7J1Wyn0pl8Dugsn4D~bD88A__&Key-Pair-Id=K1U52DHN9E92VT",
                    UserBio = "Your Career Guru",
                    CountryId = 76,
                    StateId = 17,
                    Region = "Kochi",
                    Specialization = "MBBS",
                    ConnectionsCount = 0,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedBy = 1
                });
                context.SaveChanges();
            }
            #endregion
        }
    }
}
