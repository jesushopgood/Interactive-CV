using System.Net.Mime;
using StoreFrontUK.GlobalObjects.Customer.Enums;
using StoreFrontUK.Services.CustomerService.Entities;

namespace StoreFrontUK.Services.CustomerService.Data;

public static class CustomerSeeder
{
    private static DateTime RandomDate()
    {
        var start = new DateTime(2023, 1, 1);
        var range = (DateTime.Now - start).Days;

        return start.AddDays(Random.Shared.Next(range))
                    .AddHours(Random.Shared.Next(0, 24))
                    .AddMinutes(Random.Shared.Next(0, 60))
                    .AddSeconds(Random.Shared.Next(0, 60));
    }

    public static void Seed(CustomerDbContext context)
    {
        context.CustomerNotes.RemoveRange(context.CustomerNotes);
        context.CustomerContacts.RemoveRange(context.CustomerContacts);
        context.CustomerAddresses.RemoveRange(context.CustomerAddresses);
        context.Customers.RemoveRange(context.Customers);

        context.SaveChanges();

        var guidList = Enumerable.Range(0, 60).Select(x => Guid.NewGuid()).ToList();
        var customerIndex = 0;

        if (!context.Customers.Any())
        {
            context.Customers.AddRange(
            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Albert", Surname = "Einstein" },
                CustomerEmailAddress = "albert.einstein@example.com",
                LoyaltyPoints = 120,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Ms", FirstName = "Marie", Surname = "Curie" },
                CustomerEmailAddress = "marie.curie@example.com",
                LoyaltyPoints = 95,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Isaac", Surname = "Newton" },
                CustomerEmailAddress = "isaac.newton@example.com",
                LoyaltyPoints = 150,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Leonardo", Surname = "daVinci" },
                CustomerEmailAddress = "leonardo.davinci@example.com",
                LoyaltyPoints = 80,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Nikola", Surname = "Tesla" },
                CustomerEmailAddress = "nikola.tesla@example.com",
                LoyaltyPoints = 110,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Ms", FirstName = "Cleopatra", Surname = "Philopator" },
                CustomerEmailAddress = "cleopatra@example.com",
                LoyaltyPoints = 70,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Julius", Surname = "Caesar" },
                CustomerEmailAddress = "julius.caesar@example.com",
                LoyaltyPoints = 130,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Genghis", Surname = "Khan" },
                CustomerEmailAddress = "genghis.khan@example.com",
                LoyaltyPoints = 140,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },
            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Ms", FirstName = "Joan", Surname = "ofArc" },
                CustomerEmailAddress = "joan.ofarc@example.com",
                LoyaltyPoints = 65,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "William", Surname = "Shakespeare" },
                CustomerEmailAddress = "william.shakespeare@example.com",
                LoyaltyPoints = 90,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "George", Surname = "Washington" },
                CustomerEmailAddress = "george.washington@example.com",
                LoyaltyPoints = 100,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Ms", FirstName = "Florence", Surname = "Nightingale" },
                CustomerEmailAddress = "florence.nightingale@example.com",
                LoyaltyPoints = 85,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Winston", Surname = "Churchill" },
                CustomerEmailAddress = "winston.churchill@example.com",
                LoyaltyPoints = 75,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Ms", FirstName = "Harriet", Surname = "Tubman" },
                CustomerEmailAddress = "harriet.tubman@example.com",
                LoyaltyPoints = 60,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Martin", Surname = "LutherKing" },
                CustomerEmailAddress = "martin.lutherking@example.com",
                LoyaltyPoints = 115,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },
            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Socrates", Surname = "Philosopher" },
                CustomerEmailAddress = "socrates@example.com",
                LoyaltyPoints = 55,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Plato", Surname = "Philosopher" },
                CustomerEmailAddress = "plato@example.com",
                LoyaltyPoints = 50,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Aristotle", Surname = "Philosopher" },
                CustomerEmailAddress = "aristotle@example.com",
                LoyaltyPoints = 65,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Ms", FirstName = "Hypatia", Surname = "ofAlexandria" },
                CustomerEmailAddress = "hypatia@example.com",
                LoyaltyPoints = 70,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },
            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Confucius", Surname = "Kong" },
                CustomerEmailAddress = "confucius@example.com",
                LoyaltyPoints = 95,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },
            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Alexander", Surname = "theGreat" },
                CustomerEmailAddress = "alexander.great@example.com",
                LoyaltyPoints = 140,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Ms", FirstName = "Catherine", Surname = "theGreat" },
                CustomerEmailAddress = "catherine.great@example.com",
                LoyaltyPoints = 125,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Napoleon", Surname = "Bonaparte" },
                CustomerEmailAddress = "napoleon.bonaparte@example.com",
                LoyaltyPoints = 135,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Ms", FirstName = "Queen", Surname = "Victoria" },
                CustomerEmailAddress = "queen.victoria@example.com",
                LoyaltyPoints = 90,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Charlemagne", Surname = "King" },
                CustomerEmailAddress = "charlemagne@example.com",
                LoyaltyPoints = 105,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Galileo", Surname = "Galilei" },
                CustomerEmailAddress = "galileo@example.com",
                LoyaltyPoints = 100,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Ms", FirstName = "Ada", Surname = "Lovelace" },
                CustomerEmailAddress = "ada.lovelace@example.com",
                LoyaltyPoints = 115,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Alan", Surname = "Turing" },
                CustomerEmailAddress = "alan.turing@example.com",
                LoyaltyPoints = 130,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Johannes", Surname = "Kepler" },
                CustomerEmailAddress = "johannes.kepler@example.com",
                LoyaltyPoints = 85,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Thomas", Surname = "Edison" },
                CustomerEmailAddress = "thomas.edison@example.com",
                LoyaltyPoints = 75,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },
                        new Customer
                        {
                            CustomerId = guidList[customerIndex++].ToString(),
                            CustomerName = { Title = "Ms", FirstName = "Amelia", Surname = "Earhart" },
                            CustomerEmailAddress = "amelia.earhart@example.com",
                            LoyaltyPoints = 60,
                            Addresses = [],
                            CustomerContacts = [],
                            CustomerNotes = []
                        },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Neil", Surname = "Armstrong" },
                CustomerEmailAddress = "neil.armstrong@example.com",
                LoyaltyPoints = 95,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Ms", FirstName = "Rosa", Surname = "Parks" },
                CustomerEmailAddress = "rosa.parks@example.com",
                LoyaltyPoints = 70,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Nelson", Surname = "Mandela" },
                CustomerEmailAddress = "nelson.mandela@example.com",
                LoyaltyPoints = 125,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Ms", FirstName = "Mother", Surname = "Teresa" },
                CustomerEmailAddress = "mother.teresa@example.com",
                LoyaltyPoints = 55,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Hammurabi", Surname = "King" },
                CustomerEmailAddress = "hammurabi@example.com",
                LoyaltyPoints = 80,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Ms", FirstName = "Elizabeth", Surname = "Tudor" },
                CustomerEmailAddress = "elizabeth.tudor@example.com",
                LoyaltyPoints = 100,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Homer", Surname = "Poet" },
                CustomerEmailAddress = "homer@example.com",
                LoyaltyPoints = 45,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Marco", Surname = "Polo" },
                CustomerEmailAddress = "marco.polo@example.com",
                LoyaltyPoints = 85,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Ms", FirstName = "Sacagawea", Surname = "Explorer" },
                CustomerEmailAddress = "sacagawea@example.com",
                LoyaltyPoints = 65,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Sun", Surname = "Tzu" },
                CustomerEmailAddress = "sun.tzu@example.com",
                LoyaltyPoints = 120,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Hernán", Surname = "Cortés" },
                CustomerEmailAddress = "hernan.cortes@example.com",
                LoyaltyPoints = 75,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Ms", FirstName = "Mary", Surname = "Shelley" },
                CustomerEmailAddress = "mary.shelley@example.com",
                LoyaltyPoints = 90,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex++].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Ludwig", Surname = "Beethoven" },
                CustomerEmailAddress = "ludwig.beethoven@example.com",
                LoyaltyPoints = 110,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            },

            new Customer
            {
                CustomerId = guidList[customerIndex].ToString(),
                CustomerName = { Title = "Mr", FirstName = "Wolfgang", Surname = "Mozart" },
                CustomerEmailAddress = "wolfgang.mozart@example.com",
                LoyaltyPoints = 105,
                Addresses = [],
                CustomerContacts = [],
                CustomerNotes = []
            });
        }
        context.SaveChanges();

        customerIndex = 0;
        var customerList = context.Customers.ToList();

        if (!context.CustomerAddresses.Any())
        {
            context.CustomerAddresses.AddRange(
                new CustomerAddress { Customer = customerList[customerIndex], AddressType = AddressType.Billing, Line1 = "1A Billingham St.", Line2 = "Liverpool", Postcode = "L1 4AA" },
                new CustomerAddress { Customer = customerList[customerIndex], AddressType = AddressType.Delivery, Line1 = "12 Baine St.", Line2 = "Liverpool", Postcode = "L12 5AA" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Secondary, Line1 = "13 New St.", Line2 = "Liverpool", Postcode = "L12 6AA" },

                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "22 Rosewood Ave.", Line2 = "Manchester", Postcode = "M3 2LP" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "14 Kingfisher Rd.", Line2 = "Birmingham", Postcode = "B2 5RT" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "7 Oakridge Close", Line2 = "Leeds", Postcode = "LS1 3AB" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "9 Willowbank St.", Line2 = "Glasgow", Postcode = "G1 2QQ" },

                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "31 Meadow View", Line2 = "Sheffield", Postcode = "S1 4GH" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "4 Primrose Lane", Line2 = "Newcastle", Postcode = "NE1 5PL" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "18 Brookside Way", Line2 = "Bristol", Postcode = "BS1 1AA" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "27 Ashfield Rd.", Line2 = "Nottingham", Postcode = "NG1 3LT" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "12 Maple Crescent", Line2 = "Cardiff", Postcode = "CF10 2AB" },

                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "6 Elmwood Court", Line2 = "Leicester", Postcode = "LE1 4PP" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "19 Pinehurst Dr.", Line2 = "Coventry", Postcode = "CV1 2TT" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "3 Birchwood Rise", Line2 = "Hull", Postcode = "HU1 3AA" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "25 Sycamore St.", Line2 = "Swansea", Postcode = "SA1 4BB" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "8 Heather Close", Line2 = "Derby", Postcode = "DE1 1PL" },

                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "10 Lavender Walk", Line2 = "Southampton", Postcode = "SO1 2AA" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "33 Hawthorn Rd.", Line2 = "Portsmouth", Postcode = "PO1 3LP" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "2 Bramble Gate", Line2 = "Stoke-on-Trent", Postcode = "ST1 4TT" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "11 Rowan Terrace", Line2 = "Reading", Postcode = "RG1 2AB" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "5 Cedar Way", Line2 = "Plymouth", Postcode = "PL1 3AA" },

                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "16 Orchard Lane", Line2 = "Wolverhampton", Postcode = "WV1 4PP" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "28 Foxglove Rd.", Line2 = "Milton Keynes", Postcode = "MK1 1TT" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "7 Bluebell Court", Line2 = "Aberdeen", Postcode = "AB10 1AA" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "13 Fernhill St.", Line2 = "Dundee", Postcode = "DD1 2AB" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "21 Moorland Dr.", Line2 = "York", Postcode = "YO1 7LP" },

                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "30 Ridgeway Ave.", Line2 = "Exeter", Postcode = "EX1 1AA" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "14 Cloverfield Rd.", Line2 = "Norwich", Postcode = "NR1 3TT" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "9 Thistle Grove", Line2 = "Cambridge", Postcode = "CB1 2AB" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "6 Poppy Lane", Line2 = "Oxford", Postcode = "OX1 3AA" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "17 Briarwood St.", Line2 = "Bath", Postcode = "BA1 1LP" },

                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "4 Hazelbank Rd.", Line2 = "Lancaster", Postcode = "LA1 2AB" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "22 Larkspur Way", Line2 = "Chester", Postcode = "CH1 4TT" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "3 Moorfield Close", Line2 = "Blackpool", Postcode = "FY1 3AA" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "15 Greenbank St.", Line2 = "Bolton", Postcode = "BL1 2AB" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "29 Hillcrest Rd.", Line2 = "Warrington", Postcode = "WA1 1TT" },

                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "12 Brookfield Ave.", Line2 = "Preston", Postcode = "PR1 3LP" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "8 Sandstone Dr.", Line2 = "Luton", Postcode = "LU1 2AA" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "26 Riverbank St.", Line2 = "Middlesbrough", Postcode = "TS1 4AB" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "5 Heatherfield Rd.", Line2 = "Sunderland", Postcode = "SR1 3TT" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "18 Stonegate Close", Line2 = "Brighton", Postcode = "BN1 1AA" },

                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "11 Redwood St.", Line2 = "Hastings", Postcode = "TN34 1AB" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "20 Ashgrove Rd.", Line2 = "Ipswich", Postcode = "IP1 3LP" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "7 Millstream Way", Line2 = "Colchester", Postcode = "CO1 2AA" },
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "13 Fairview Close", Line2 = "Gloucester", Postcode = "GL1 4TT" },
                new CustomerAddress { Customer = customerList[customerIndex], AddressType = AddressType.Billing, Line1 = "24 Bracken Rd.", Line2 = "Winchester", Postcode = "SO23 1AB" }
            );
        }

        context.SaveChanges();
        customerIndex = 0;

        if (!context.CustomerContacts.Any())
        {
            context.CustomerContacts.AddRange(
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa1@aa.com" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111221" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa2@aa.com" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111222" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa3@aa.com" },

                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111223" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa4@aa.com" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111224" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa5@aa.com" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111225" },

                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa6@aa.com" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111226" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa7@aa.com" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111227" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa8@aa.com" },

                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111228" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa9@aa.com" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111229" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa10@aa.com" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111230" },

                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa11@aa.com" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111231" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa12@aa.com" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111232" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa13@aa.com" },

                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111233" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa14@aa.com" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111234" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa15@aa.com" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111235" },

                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa16@aa.com" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111236" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa17@aa.com" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111237" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa18@aa.com" },

                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111238" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa19@aa.com" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111239" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa20@aa.com" },
                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Mobile, Value = "07900111240" },

                new CustomerContact { Customer = customerList[customerIndex++], CustomerContactType = CustomerContactType.Email, Value = "aa30@aa.com" }
            );
        }

        customerIndex = 0;
        if (!context.CustomerNotes.Any())
        {
            context.CustomerNotes.AddRange(
                new CustomerNote { Customer = customerList[customerIndex], Message = "My package was late", MessageDate = RandomDate() },
                new CustomerNote { Customer = customerList[customerIndex], Message = "It arrived a day late", MessageDate = RandomDate() },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "There was no can opener", MessageDate = RandomDate() },

                new CustomerNote { Customer = customerList[customerIndex++], Message = "My dog ate the package", MessageDate = RandomDate() },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "I will be out on Tuesday", MessageDate = RandomDate() },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "Why have you sent me incontinence pads?", MessageDate = RandomDate() },

                new CustomerNote { Customer = customerList[customerIndex++], Message = "Please leave parcels with my neighbour", MessageDate = RandomDate() },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "I need to update my email address", MessageDate = RandomDate() },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "The item arrived damaged", MessageDate = RandomDate() },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "I received the wrong colour", MessageDate = RandomDate() },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "I want to change my delivery slot", MessageDate = RandomDate() },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "Please call before delivery", MessageDate = RandomDate() },

                new CustomerNote { Customer = customerList[customerIndex++], Message = "The courier left the parcel in the rain", MessageDate = RandomDate() },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "I need an invoice for my order", MessageDate = RandomDate() },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "The packaging was excessive", MessageDate = RandomDate() },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "I am still waiting for a refund", MessageDate = RandomDate() },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "I will be on holiday next week", MessageDate = RandomDate() },

                new CustomerNote { Customer = customerList[customerIndex++], Message = "The product did not match the description", MessageDate = RandomDate() },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "Please deliver to the back door", MessageDate = RandomDate() },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "I accidentally ordered twice", MessageDate = RandomDate() },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "My address has changed recently", MessageDate = RandomDate() },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "The driver was very helpful", MessageDate = RandomDate() },

                new CustomerNote { Customer = customerList[customerIndex++], Message = "I need to cancel my order" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "The parcel was left with the wrong neighbour" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "I received an empty box" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "The tracking information is incorrect" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "Please avoid delivering before 9am" },

                new CustomerNote { Customer = customerList[customerIndex++], Message = "I think I was charged twice" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "The product is missing a part" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "I would like to leave feedback" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "The parcel was left in a safe place, thank you" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "I need help with my account login" }
            );

        }
        context.SaveChanges();
    }
}