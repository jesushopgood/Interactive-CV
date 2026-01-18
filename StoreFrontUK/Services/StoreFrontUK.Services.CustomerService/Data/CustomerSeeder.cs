using System.Net.Mime;
using StoreFrontUK.GlobalObjects.Customer.Enums;
using StoreFrontUK.Services.CustomerService.Entities;

namespace StoreFrontUK.Services.CustomerService.Data;

public static class CustomerSeeder
{
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
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Albert", CustomerSurname = "Einstein", CustomerEmailAddress = "albert.einstein@example.com", LoyaltyPoints = 120, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Ms", CustomerFirstName = "Marie", CustomerSurname = "Curie", CustomerEmailAddress = "marie.curie@example.com", LoyaltyPoints = 95, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Isaac", CustomerSurname = "Newton", CustomerEmailAddress = "isaac.newton@example.com", LoyaltyPoints = 150, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Leonardo", CustomerSurname = "daVinci", CustomerEmailAddress = "leonardo.davinci@example.com", LoyaltyPoints = 80, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Nikola", CustomerSurname = "Tesla", CustomerEmailAddress = "nikola.tesla@example.com", LoyaltyPoints = 110, Addresses = [], CustomerContacts = [], CustomerNotes = [] },

                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Ms", CustomerFirstName = "Cleopatra", CustomerSurname = "Philopator", CustomerEmailAddress = "cleopatra@example.com", LoyaltyPoints = 70, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Julius", CustomerSurname = "Caesar", CustomerEmailAddress = "julius.caesar@example.com", LoyaltyPoints = 130, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Genghis", CustomerSurname = "Khan", CustomerEmailAddress = "genghis.khan@example.com", LoyaltyPoints = 140, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Ms", CustomerFirstName = "Joan", CustomerSurname = "ofArc", CustomerEmailAddress = "joan.ofarc@example.com", LoyaltyPoints = 65, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "William", CustomerSurname = "Shakespeare", CustomerEmailAddress = "william.shakespeare@example.com", LoyaltyPoints = 90, Addresses = [], CustomerContacts = [], CustomerNotes = [] },

                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "George", CustomerSurname = "Washington", CustomerEmailAddress = "george.washington@example.com", LoyaltyPoints = 100, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Ms", CustomerFirstName = "Florence", CustomerSurname = "Nightingale", CustomerEmailAddress = "florence.nightingale@example.com", LoyaltyPoints = 85, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Winston", CustomerSurname = "Churchill", CustomerEmailAddress = "winston.churchill@example.com", LoyaltyPoints = 75, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Ms", CustomerFirstName = "Harriet", CustomerSurname = "Tubman", CustomerEmailAddress = "harriet.tubman@example.com", LoyaltyPoints = 60, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Martin", CustomerSurname = "LutherKing", CustomerEmailAddress = "martin.lutherking@example.com", LoyaltyPoints = 115, Addresses = [], CustomerContacts = [], CustomerNotes = [] },

                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Socrates", CustomerSurname = "Philosopher", CustomerEmailAddress = "socrates@example.com", LoyaltyPoints = 55, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Plato", CustomerSurname = "Philosopher", CustomerEmailAddress = "plato@example.com", LoyaltyPoints = 50, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Aristotle", CustomerSurname = "Philosopher", CustomerEmailAddress = "aristotle@example.com", LoyaltyPoints = 65, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Ms", CustomerFirstName = "Hypatia", CustomerSurname = "ofAlexandria", CustomerEmailAddress = "hypatia@example.com", LoyaltyPoints = 70, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Confucius", CustomerSurname = "Kong", CustomerEmailAddress = "confucius@example.com", LoyaltyPoints = 95, Addresses = [], CustomerContacts = [], CustomerNotes = [] },

                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Alexander", CustomerSurname = "theGreat", CustomerEmailAddress = "alexander.great@example.com", LoyaltyPoints = 140, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Ms", CustomerFirstName = "Catherine", CustomerSurname = "theGreat", CustomerEmailAddress = "catherine.great@example.com", LoyaltyPoints = 125, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Napoleon", CustomerSurname = "Bonaparte", CustomerEmailAddress = "napoleon.bonaparte@example.com", LoyaltyPoints = 135, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Ms", CustomerFirstName = "Queen", CustomerSurname = "Victoria", CustomerEmailAddress = "queen.victoria@example.com", LoyaltyPoints = 90, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Charlemagne", CustomerSurname = "King", CustomerEmailAddress = "charlemagne@example.com", LoyaltyPoints = 105, Addresses = [], CustomerContacts = [], CustomerNotes = [] },

                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Galileo", CustomerSurname = "Galilei", CustomerEmailAddress = "galileo@example.com", LoyaltyPoints = 100, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Ms", CustomerFirstName = "Ada", CustomerSurname = "Lovelace", CustomerEmailAddress = "ada.lovelace@example.com", LoyaltyPoints = 115, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Alan", CustomerSurname = "Turing", CustomerEmailAddress = "alan.turing@example.com", LoyaltyPoints = 130, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Johannes", CustomerSurname = "Kepler", CustomerEmailAddress = "johannes.kepler@example.com", LoyaltyPoints = 85, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Thomas", CustomerSurname = "Edison", CustomerEmailAddress = "thomas.edison@example.com", LoyaltyPoints = 75, Addresses = [], CustomerContacts = [], CustomerNotes = [] },

                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Ms", CustomerFirstName = "Amelia", CustomerSurname = "Earhart", CustomerEmailAddress = "amelia.earhart@example.com", LoyaltyPoints = 60, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Neil", CustomerSurname = "Armstrong", CustomerEmailAddress = "neil.armstrong@example.com", LoyaltyPoints = 95, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Ms", CustomerFirstName = "Rosa", CustomerSurname = "Parks", CustomerEmailAddress = "rosa.parks@example.com", LoyaltyPoints = 70, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Nelson", CustomerSurname = "Mandela", CustomerEmailAddress = "nelson.mandela@example.com", LoyaltyPoints = 125, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Ms", CustomerFirstName = "Mother", CustomerSurname = "Teresa", CustomerEmailAddress = "mother.teresa@example.com", LoyaltyPoints = 55, Addresses = [], CustomerContacts = [], CustomerNotes = [] },

                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Hammurabi", CustomerSurname = "King", CustomerEmailAddress = "hammurabi@example.com", LoyaltyPoints = 80, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Ms", CustomerFirstName = "Elizabeth", CustomerSurname = "Tudor", CustomerEmailAddress = "elizabeth.tudor@example.com", LoyaltyPoints = 100, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Homer", CustomerSurname = "Poet", CustomerEmailAddress = "homer@example.com", LoyaltyPoints = 45, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Marco", CustomerSurname = "Polo", CustomerEmailAddress = "marco.polo@example.com", LoyaltyPoints = 85, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Ms", CustomerFirstName = "Sacagawea", CustomerSurname = "Explorer", CustomerEmailAddress = "sacagawea@example.com", LoyaltyPoints = 65, Addresses = [], CustomerContacts = [], CustomerNotes = [] },

                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Sun", CustomerSurname = "Tzu", CustomerEmailAddress = "sun.tzu@example.com", LoyaltyPoints = 120, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Hernán", CustomerSurname = "Cortés", CustomerEmailAddress = "hernan.cortes@example.com", LoyaltyPoints = 75, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Ms", CustomerFirstName = "Mary", CustomerSurname = "Shelley", CustomerEmailAddress = "mary.shelley@example.com", LoyaltyPoints = 90, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex++].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Ludwig", CustomerSurname = "Beethoven", CustomerEmailAddress = "ludwig.beethoven@example.com", LoyaltyPoints = 110, Addresses = [], CustomerContacts = [], CustomerNotes = [] },
                new Customer { CustomerId = guidList[customerIndex].ToString(), CustomerTitle = "Mr", CustomerFirstName = "Wolfgang", CustomerSurname = "Mozart", CustomerEmailAddress = "wolfgang.mozart@example.com", LoyaltyPoints = 105, Addresses = [], CustomerContacts = [], CustomerNotes = [] });
        }

        context.SaveChanges();

        customerIndex = 0;
        var customerList = context.Customers.ToList();

        if (!context.CustomerAddresses.Any())
        {
            context.CustomerAddresses.AddRange(
                new CustomerAddress { Customer = customerList[customerIndex++], AddressType = AddressType.Billing, Line1 = "1A Billingham St.", Line2 = "Liverpool", Postcode = "L1 4AA" },
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
                new CustomerNote { Customer = customerList[customerIndex++], Message = "My package was late" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "My dog ate the package" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "I will be out on Tuesday" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "Why have you sent me incontinence pads?" },

                new CustomerNote { Customer = customerList[customerIndex++], Message = "Please leave parcels with my neighbour" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "I need to update my email address" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "The item arrived damaged" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "I received the wrong colour" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "I want to change my delivery slot" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "Please call before delivery" },

                new CustomerNote { Customer = customerList[customerIndex++], Message = "The courier left the parcel in the rain" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "I need an invoice for my order" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "The packaging was excessive" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "I am still waiting for a refund" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "I will be on holiday next week" },

                new CustomerNote { Customer = customerList[customerIndex++], Message = "The product did not match the description" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "Please deliver to the back door" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "I accidentally ordered twice" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "My address has changed recently" },
                new CustomerNote { Customer = customerList[customerIndex++], Message = "The driver was very helpful" },

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