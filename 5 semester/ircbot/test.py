#!/usr/bin/python

import sys
import asyncio

class Prompt:
    def __init__(self, loop):
        self.loop = loop
        self.q = asyncio.Queue(loop=self.loop)
        self.loop.add_reader(sys.stdin, self.receive)
        self.loop.add

    def receive(self):
        #asyncio.ensure_future(self.q.put(sys.stdin.readline()), loop=self.loop)
        print('...rcvd...:', sys.stdin.readline())

    def send(self):


    async def __call__(self, prompt, end='', flush=True):
        print(prompt, end=end, flush=flush)
        return (await self.q.get()).rstrip('\n')

async def countdown(tics=5):
    while tics > 0:
        print('-' + str(tics))
        await asyncio.sleep(1)
        tics -= 1

async def main():
    data = ''
    while data != 'stop':
        await countdown()
        data = await prompt('input "stop" to stop this madness ->')
        print('\t' + data)

if __name__ == "__main__":
    loop = asyncio.get_event_loop()
    prompt = Prompt(loop)
    loop.run_until_complete(main())
    loop.close

