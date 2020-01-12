import sys
from telethon import TelegramClient, events

api_id = 1197587
api_hash = '416fa041842875dc060c305c02b1299c'
client = TelegramClient('anon', api_id, api_hash)

try:
    phone_number = sys.argv[1]
    is_new_conversation = sys.argv[2]
    if is_new_conversation == "True":
        is_new_conversation = True
    else:
        is_new_conversation = False
except:
    phone_number = "+972504182088"
    is_new_conversation = True


async def main():
    if is_new_conversation is True:
        await client.send_message(phone_number, 'Hi from Information Kiosk\nplease send here your ice cream picture')
    else:
        await client.send_message(phone_number, 'Hi \nthe image you have sent us is not an ice cream image.\nplease '
                                                'send us a new image')


@client.on(events.NewMessage(incoming=True, from_users=phone_number))
async def my_event_handler(event):
    if event.message.photo:
        await event.message.download_media(file="ice-cream-pic.jpg")
        exit()
    else:
        await event.reply("we expect you to send an image file")


if __name__ == '__main__':
    with client:
        client.loop.run_until_complete(main())
    client.start()
    client.run_until_disconnected()
