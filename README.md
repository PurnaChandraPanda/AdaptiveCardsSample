# Adaptive Cards sample

This adaptive cards sample would just help walkthrough the use case of various Adaptive Cards usage.

## Details

- This app is just an enhancement of our [sample](https://github.com/microsoft/BotBuilder-Samples/tree/master/samples/csharp_dotnetcore/07.using-adaptive-cards).
- Instead of utilizing random logic, made it to follow user input based.
- [Adaptive Cards](https://adaptivecards.io/explorer/) are a great way to connect user with well wrapped contents.
- For dropdown in card, [Input.ChoiceSet](https://adaptivecards.io/explorer/Input.ChoiceSet.html) is the best option to go with, which further can be associated with [Action.Submit](https://adaptivecards.io/explorer/Action.Submit.html) for productivity.
- On submit from `ChoiceSet`, you can just read the associated value from client and pass it to service.

## Core logic

It might sound very old school. This can be enhanced futher that fit to business requirements.

```diff
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
+                if (turnContext.Activity.Value != null) {
+                    await turnContext.SendActivityAsync(MessageFactory.Text(turnContext.Activity.Value.ToString()), cancellationToken);
                    return;
                }
+                cardAttachment = CreateAdaptiveCardAttachment(_cards[5]);
            }

+            await turnContext.SendActivityAsync(MessageFactory.Attachment(cardAttachment), cancellationToken);
```