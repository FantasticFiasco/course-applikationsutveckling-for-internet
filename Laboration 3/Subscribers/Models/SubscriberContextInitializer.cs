﻿using System.Collections.Generic;
using System.Data.Entity;

namespace Subscribers.Models
{
    public class SubscriberContextInitializer : DropCreateDatabaseIfModelChanges<SubscriberContext>
    {
        protected override void Seed(SubscriberContext context)
        {
            foreach (Subscriber subscriber in CreateSubscribers())
            {
                context.Subscribers.Add(subscriber);
            }
        }

        private static IEnumerable<Subscriber> CreateSubscribers()
        {
            yield return CreateSubscriber("111111", "19450316-1111", "Martha", "Burkett", "482 Chandler Hollow Road", 15210, "Pittsburgh");
            yield return CreateSubscriber("222222", "19401020-2222", "Melinda", "Jara", "3870 Hewes Avenue", 21202, "Baltimore");
            yield return CreateSubscriber("333333", "19330926-3333", "John", "Plaisted", "371 Morningview Lane", 50836, "Blockton");
            yield return CreateSubscriber("444444", "19521121-4444", "Emerson", "Crow", "378 Java Lane", 29115, "Orangeburg");
            yield return CreateSubscriber("555555", "19760529-5555", "Brittany", "Borden", "2600 Rainy Day Drive", 02141, "Cambridge");
            yield return CreateSubscriber("666666", "19900717-6666", "Richard", "Ali", "2146 Blackwell Street", 99503, "Anchorage");
            yield return CreateSubscriber("777777", "19740623-7777", "Hui", "Sutton", "2155 Highland Drive", 54301, "Green Bay");
            yield return CreateSubscriber("888888", "19961031-8888", "Patrick", "Figueroa", "4522 Edgewood Avenue", 93721, "Fresno");
            yield return CreateSubscriber("999999", "19750917-9999", "Willie", "Sipe", "3582 Hiddenview Drive", 44131, "Independence");
        }

        private static Subscriber CreateSubscriber(
            string subscriptionNumber,
            string socialSecurityNumber,
            string firstName,
            string surname,
            string street,
            int postalCode,
            string city)
        {
            return new Subscriber
            {
                SubscriptionNumber = subscriptionNumber,
                SocialSecurityNumber = socialSecurityNumber,
                FirstName = firstName,
                Surname = surname,
                Street = street,
                PostalCode = postalCode,
                City = city
            };
        }
    }
}