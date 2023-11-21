using SOSResources.Models;


namespace SOSResources.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SOSContext context)
        {
            // Look for any participants.
            if (context.Participants.Any())
            {
                return;   // DB has been seeded
            };


            var zach = new Participant
            {
                Name = "Zach",
                FirstName = "Zachary",
                LastName = "Bernheimer"
            };

            var bob = new Participant
            {
                Name = "Bob",
                FirstName = "Robert",
                LastName = "Smith"
            };

            var participants = new Participant[]
            {
                zach,
                bob
            };

            context.AddRange(participants);


            var gebusi = new Textbook
            {
                Title = "The Gebusi: Rainforest Living",
                Author = "Bruce Knauft",
                Edition = "5th"
            };

           var caseHealth = new Textbook
           {
                Title = "Case Studies for Health, Research and Practice in Australia and New Zealand",
                Author = "Nicola Whiteing"
           };

            var textbooks = new Textbook[]
            {
                gebusi,
                caseHealth
            };

            context.AddRange(textbooks);

            var c1 = new Copy{
                textbook = gebusi,
                CheckedOut = false
            };
            var c2 = new Copy{
                textbook = gebusi,
                CheckedOut = true

            };
            var c3 = new Copy{
                textbook = caseHealth,
                CheckedOut = false
            };

            var copies = new Copy[]
            {
                c1,
                c2,
                c3
            };

            context.AddRange(copies);

            var textbookRequests = new TextbookRequest[]
            {
                new TextbookRequest {
                    copy = c2,
                    Participant = zach,
                    Active = true
                }
            };

            context.AddRange(textbookRequests);
            context.SaveChanges();
        }
    }
}