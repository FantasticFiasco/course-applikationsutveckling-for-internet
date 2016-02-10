using System;
using System.Data.Entity;

namespace TravelDiary.Models
{
    public class ApplicationDbContextInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.DiaryEntries.Add(CreateDiaryEntry(
                "My first entry",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris ultrices mi vitae tristique tincidunt. Aenean vehicula urna libero, eu tincidunt ex varius nec. Duis sollicitudin venenatis enim lobortis tincidunt. Vivamus sagittis elit at porttitor interdum. Duis volutpat tincidunt blandit. Quisque ut tortor leo. Nam rhoncus faucibus commodo. Proin blandit erat libero, vel consequat justo egestas ut. Sed dapibus ex dolor, non cursus dui elementum sed. Vestibulum eget ipsum odio. Nulla vitae imperdiet lacus.",
                new DateTime(2015, 1, 1)));

            context.DiaryEntries.Add(CreateDiaryEntry(
                "My second entry",
                "Fusce at justo vel sem fermentum semper quis ac ligula. Mauris viverra nisi eu elit fringilla laoreet. Donec posuere massa neque. Nullam nec facilisis eros. Duis vestibulum justo mi, cursus sagittis nulla porttitor interdum. Praesent sagittis vehicula tincidunt. Integer rhoncus quam sit amet mattis venenatis. Quisque efficitur quis lectus sit amet bibendum. Ut pulvinar ligula interdum varius ornare. Cras sed auctor ex. Sed aliquet consequat leo, eget venenatis orci blandit non. Sed non egestas nulla. In tincidunt dolor sed massa fermentum, id vestibulum ex venenatis. Praesent a felis bibendum, lobortis urna eu, maximus lacus. Vestibulum rutrum erat et ipsum fringilla, sed semper diam luctus.",
                new DateTime(2015, 1, 15)));

            context.DiaryEntries.Add(CreateDiaryEntry(
                "My third entry",
                "Nunc semper, massa blandit consectetur venenatis, lorem enim elementum purus, a ultricies nisi dui in massa. Duis commodo est ut auctor finibus. Aenean vel aliquam lectus, et tristique nunc. Vestibulum ante ante, malesuada sit amet arcu interdum, mattis vehicula elit. Duis ut purus suscipit, mollis nunc congue, congue dolor. Vivamus suscipit et neque posuere ornare. Donec lacinia condimentum justo, eget pretium mi vestibulum id. Vestibulum molestie turpis eu ante semper, vel egestas elit volutpat. Donec egestas enim lectus, eget vestibulum risus semper at. Proin ut mattis dui. Cras eu sem vestibulum, pellentesque sapien nec, fermentum felis. Quisque at nunc diam. Aenean pharetra ornare justo sed porta.",
                new DateTime(2015, 2, 7)));
        }

        private static DiaryEntry CreateDiaryEntry(
            string title,
            string content,
            DateTime created)
        {
            return new DiaryEntry
            {
                Title = title,
                Content = content,
                Created = created
            };
        }
    }
}