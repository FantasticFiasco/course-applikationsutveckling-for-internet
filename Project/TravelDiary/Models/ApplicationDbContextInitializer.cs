using System;
using System.Data.Entity;

namespace TravelDiary.Models
{
    public class ApplicationDbContextInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            DiaryEntry firstEntry = context.DiaryEntries.Add(CreateDiaryEntry(
                "Thank you India - keep calm and curry on!",
                "India has undoubtedly given me a new inner sparkle that was not there before I left. I find it hard to describe what this actually is but it's there. It could be because I have wanted to see India for a long time and I am very grateful I have now been and discovered some of it, or maybe it is because I have had my eyes opened to how I can practice gaining inner happiness from meditation and everything I learned in Rishikesh. In a lot of ways I don't even want to question it but focus on living in the now and enjoying life!<br/><br/>This has been the starting point of a trip of a lifetime that I have wanted to undertake for many years and had to work hard to get. What a start to my journey! I have been literally blown away by India. In two and a half months I have learnt so much from everyone I have met regarding; religion, philosophy, yoga, Ayurvedic medicine and treatments, the north and south of India and how they differ, the differences between the east and west, what colonial rule of India was like and its subsequent independence, patience, management of expectations, the cuisine....so much. If you are open to learning, India is the right place to be. I have been changed irreversibly by India and I am very grateful for it.<br/><br/>Life lessons - some gained the hard way, some gained the easy way. Travelling in India can be really hard. I found some of the travelling pretty tough at times. Delayed trains, invaded personal space, cramped and sometimes dirty conditions, people staring at you, long journeys and hot weather can really test your patience. My boundaries of tolerance were pushed and I like to think I have grown from these travelling experiences. My time in India has also led me to examine my expectations and start to get a better understanding of the 'east' and 'west' mentalities. In the west we need everything to time, quality and demand and if we do not get it, there has to be a good reason. In the east everyone is a lot more laid back about life. When something goes wrong there is an air of calmness and taking your time to solve the issue in hand. More 'taking life as it comes' rather than 'trying hard to get the result you want all of the time'. You need patience, an open mind and a 'go with the flow' mentality in India. This is probably something for me to ponder further on my travels east!",
                new DateTime(2015, 1, 2),
                "Mumbai, India",
                18.975,
                72.8258));

            DiaryEntry secondEntry = context.DiaryEntries.Add(CreateDiaryEntry(
                "Stop and Start in Bangkok",
                "Chiang Mai and Bangkok are worlds apart. I literally landed with a bump when I stepped off the flight and had to queue in an epic line for the taxi into town. My white knuckle ride by a very accomplished racing driver/ taxi driver also brought it home that the capital of the Lanna Kingdom was far behind! Driving is different in Asia, there is no orderly slow, medium and fast lanes, oh no! There are lanes with traffic and the idea is to jump from one lane to the other, where there is a space, to be able to continue to travel at light speed until you get to your destination.<br/><br/>My destination was thankfully reached safely and I crashed for the night, only to wake a short while later in a perfect spot for wandering around Bangkok, the touristy areas that is. During a previous trip to Cambodia and Vietnam I spent a full day in Bangkok seeing a lot of the main touristy sites such as The Royal Palace, the redlining Buddha temple climbing the sky high Wat Arun and having a thai massage in the massage school. As I did not want to repeat any of that for my second visit I hit the museums!<br/><br/><a href=\"http://www.bangkok.com/attraction-museum/national-museum.htm\">The National Museum</a> turned out to be an extensive and slightly bizarre collection of Thai artefacts and buildings spanning century's. Asian, Lanna, Java and ancient Hindu art competed with exhibitions housing royal funeral chariots, ceramics, textiles and the Red House, a beautifully preserved teak house built about 200 years ago for a sister of King Rama I.<br/><br/><a href=\"http://www.bangkok.com/magazine/national-art-gallery.htm\">The National Gallery</a> in Bangkok, just over the road from the The National Museum, also houses a slightly bizarre collection of art. The art here spans traditional Thai and Hindu art, modern art and touring exhibitions. It was wonderful because after getting up early, I arrived at the museum on the dot of 9 am, the museum opening time and not surprisingly, I was the first customer to enter the museum that day and purchase my 200 baht ticket.<br/><br/>I have never experienced a museum come alive before, a privilege normally reserved for museum employees, but here I was walking up to the upstairs gallery with the attendant switching on the lights and throwing open the glass doors for me to enter. The art work revealed itself out of the gloom as the lights turned on, replacing sunlight arches made by the window slats and I exclusively wandered around taking in the art produced over centuries." + "The grand finale came when I reached the temporary exhibition room. The simplistically entitled exhibition poster, 'Siam' enticed me in with a bold black and white photograph of what appeared to be a young Thai Prince in glorious detail. This perfectly presented exhibition showcased a collection of enhanced photographs by John Thomson, a famous photographer and travel writer between and 1837 - 1921. Photographs he had taken in Thailand, Cambodia and coastal China between 1865 and 1866, illustrated unique snapshots of what life was like back then, in the emerging era of photography.",
                new DateTime(2015, 2, 15),
                "Bangkok, Thailand",
                13.75,
                100.5));

            DiaryEntry thirdEntry = context.DiaryEntries.Add(CreateDiaryEntry(
                "Beijing Delivers",
                "China is a country of ancient myths, dragons, emperors, the one child policy, communism, the giant panda and dramatic landscapes. I had started my journey across China in Beijing and seen the Great Wall of China, however, now it was time to get to know Beijing a bit better before continuing onto Shanghai.<br/><br/>China's population is the largest in the world standing at 1.4 billion people of which approximately 25 million live in Beijing. Not surprisingly, a population of this size can present certain challenges at a societal level. Large populations demand resources at all levels and ages within society, including; child care, schooling, employment and healthcare. Back in the late 70's, China recognised that unless they put in place a radical policy to control the population size, the quality of life for the general population as a whole would dramatically deteriorate and affect the country for generations. Therefore the governments solution was to put in place the one child policy which was enacted in 1980, which stipulated that couples are only allowed one child or they will be fined and loose benefits that would have been given to them if they had just had <a href=\"http://en.m.wikipedia.org/wiki/One-child_policy\">one child</a>.<br/><br/>Even though this policy might seem harsh, the incentives, both carrot and stick has had some success and China's population growth has been curbed compared to what it could be today compared to what it could have been if there was no policy in place. It could be argued that not all of the outcomes from the policy have been beneficial such as child infanticide and spoilt children syndrome however, the policy has now been relaxed slightly so that if a married couple were both from one child families, they are allowed two children without having any penalties.<br/><br/>A large population also presents challenges in the form of living space. Beijing's real estate is sky high and apartment sizes are much smaller than in other countries. For example, a 60 by 80 square meter apartment can easy be over 5 million yuan. With average salaries between 7-9000 yuan a month, buying even a small place to live can be unaffordable for the average family. If you count other costs that need to be covered such as schooling, fees can be 20,000 yuan a year for primary school and 10,500 yuan a semester for senior school, then this can be crippling.",
                new DateTime(2015, 3, 11),
                "Beijing, China",
                39.9,
                116.383333));

            context.SaveChanges();

            firstEntry.NextId = secondEntry.Id;
            
            secondEntry.PreviousId = firstEntry.Id;
            secondEntry.NextId = thirdEntry.Id;

            thirdEntry.PreviousId = secondEntry.Id;
        }

        private static DiaryEntry CreateDiaryEntry(
            string title,
            string content,
            DateTime created,
            string destinationName,
            double latitude,
            double longitude)
        {
            return new DiaryEntry
            {
                Title = title,
                Content = content,
                Date = created,
                Destination = new Destination
                {
                    Name   = destinationName,
                    Latitude = latitude,
                    Longitude = longitude
                }
            };
        }
    }
}