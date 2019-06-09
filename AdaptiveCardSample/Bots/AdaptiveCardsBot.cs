// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.3.0

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;

namespace AdaptiveCardSample.Bots
{
    public class AdaptiveCardsBot : ActivityHandler
    {
        private const string WelcomeText = @"This bot will introduce you to AdaptiveCards.
                                            Type anything to see an AdaptiveCard.";

        // This array contains the file location of our adaptive cards
        private readonly string[] _cards =
        {
            Path.Combine(".", "Resources", "FlightItineraryCard.json"),
            Path.Combine(".", "Resources", "ImageGalleryCard.json"),
            Path.Combine(".", "Resources", "LargeWeatherCard.json"),
            Path.Combine(".", "Resources", "RestaurantCard.json"),
            Path.Combine(".", "Resources", "SolitaireCard.json"),
            Path.Combine(".", "Resources", "appointmentCard.json"),
        };
                

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            await SendWelcomeMessageAsync(turnContext, cancellationToken);
        }
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            //Random r = new Random();
            //var cardAttachment = CreateAdaptiveCardAttachment(_cards[r.Next(_cards.Length)]);
            Attachment cardAttachment;

            if (turnContext.Activity.Text =="flight"){
                cardAttachment = CreateAdaptiveCardAttachment(_cards[0]);
            }
            else if(turnContext.Activity.Text == "image")
            {
                cardAttachment = CreateAdaptiveCardAttachment(_cards[1]);
            }
            else if (turnContext.Activity.Text == "weather")
            {
                cardAttachment = CreateAdaptiveCardAttachment(_cards[2]);
            }
            else if (turnContext.Activity.Text == "resto")
            {
                cardAttachment = CreateAdaptiveCardAttachment(_cards[3]);
            }
            else if (turnContext.Activity.Text == "solitaire")
            {
                cardAttachment = CreateAdaptiveCardAttachment(_cards[4]);
            }
            else
            {
                if (turnContext.Activity.Value != null) {
                    await turnContext.SendActivityAsync(MessageFactory.Text(turnContext.Activity.Value.ToString()), cancellationToken);
                    return;
                }
                cardAttachment = CreateAdaptiveCardAttachment(_cards[5]);
            }

            await turnContext.SendActivityAsync(MessageFactory.Attachment(cardAttachment), cancellationToken);
            await turnContext.SendActivityAsync(MessageFactory.Text("Please enter any text to see another card."), cancellationToken);
        }

        private static async Task SendWelcomeMessageAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in turnContext.Activity.MembersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(
                        $"Welcome to Adaptive Cards Bot {member.Name}. {WelcomeText}",
                        cancellationToken: cancellationToken);
                }
            }
        }

        private static Attachment CreateAdaptiveCardAttachment(string filePath)
        {
            var adaptiveCardJson = File.ReadAllText(filePath);
            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
    }
}
