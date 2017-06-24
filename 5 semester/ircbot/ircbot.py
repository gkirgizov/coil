#!/usr/bin/python3

import sys
import re
import signal
import argparse
import asyncio
from socket import *
from mazegen import mazegen

class Bot:
    def __init__(self, args, loop=None):
        self.help_msg = '===> ЗДЕСЬ МОГЛА БЫТЬ ВАША РЕКЛАМА <==='
        self.exit_code = 'bye'
        self.exit_msg = 'asta la vista'
        self.dont_understand_msg = "cannot understand you. try 'help' command."
        self.do_log= False

        self.args = args
        self.s = socket(AF_INET, SOCK_STREAM)
        self.loop = loop or asyncio.get_event_loop()
        self.loop.add_reader(sys.stdin, self.receive_user_input)
        for signame in ('SIGINT', 'SIGTERM'):
            self.loop.add_signal_handler(getattr(signal, signame), self.quit)

    def run(self):
        self.loop.run_forever()

    def quit(self):
        self.ssend('QUIT {}'.format(self.exit_msg))
        self.loop.remove_reader(self.s)
        #self.loop.remove_reader(sys.stdin)
        self.loop.stop()
        self.s.close()

    def connect(self):
        hp = (self.args.server, self.args.port)
        self.s.connect(hp)
        self.loop.add_reader(self.s, self.receive_irc)

        self.ssend('NICK {}'.format(self.args.nickname))
        self.ssend('USER {} {} {} :{}'.format(self.args.identity, 'England', self.args.server, 'William'))
        self.ssend('JOIN {}'.format(self.args.channel))

    def ssend(self, msg):
        data = bytes(msg + '\r\n', 'UTF-8')
        if self.do_log:
            print('--sent-->' + data.decode(), end='')
        self.loop.sock_sendall(self.s, data)

    def receive_user_input(self):
        msg = sys.stdin.readline().rstrip()

        # if we are experiencing control command
        if len(msg) > 0:
            if msg[0] == '!':
                msg = msg[1:]
                if msg[:4] == 'quit':
                    self.quit()
                elif msg[:3] == 'raw':
                    self.ssend(msg[3:])
                elif msg[:5] == 'names':
                    self.ssend('NAMES {}'.format(self.args.channel))
                elif msg[:3] == 'who':
                    self.ssend('WHO {}'.format(msg[3:]))
                elif msg[:3] == 'log':
                    self.do_log = True
                    if msg[3:].find('off') != -1:
                        self.do_log = False
                elif msg[:5] == 'magic':
                    self.magic(self.args.nickname, msg[5:])
                else:
                    print('UNKNOWN COMMAND')
            # if it is usual message (PRIVMSG)
            else:
                send_to = self.args.channel
                if len(msg) > 1 and (msg[0] == '@' or msg[0] == '#'):
                    nickname_end = msg.find(' ')
                    if nickname_end == -1:
                        send_to = msg[1:]
                    send_to = msg[1: nickname_end]
                    msg = msg[nickname_end + 1:]
                self.ssend('PRIVMSG {} :{}'.format(send_to, msg))

    def receive_irc(self):
        data = self.s.recv(8192).decode('UTF-8')
        lines = list(filter(None, data.split('\n')))

        for imsg in lines:
            line = imsg.rstrip().split()

            # preventing errors with empty lines
            while len(line) < 4:
                line.append([''])

            if line[0] == 'PING':
                self.ssend('PONG ' + line[1])
            elif line[1] == 'PRIVMSG':
                receiver = line[2]
                sender = ''
                for char in line[0]:
                    if char == '!':
                        break
                    if char != ':':
                        sender += char

                msg = ' '.join(line[3:])
                msg = msg.strip(' :')
                just = 14
                print(':{} '.format(sender).ljust(just, '-') + '-> {} :'.format(receiver).rjust(just, '-') + msg)
                #print(':{} -> {} :{}'.format(sender, receiver, msg))

                if imsg.find(self.args.nickname) != -1:
                    whereismagic = msg.find('magic')
                    if whereismagic != -1:
                        self.magic(sender, msg[whereismagic:])
                    elif msg.strip() == 'help':
                        self.ssend('PRIVMSG {} :{}'.format(sender, self.help_msg))
                    elif msg == self.exit_code:
                        print('EXIT REQUESTED')
                        self.quit()
                    elif sender == self.args.nickname:
                        pass
                        #print(')))ECHO)))')
                    else:
                        self.ssend('PRIVMSG {} :{}'.format(sender, self.dont_understand_msg))
            else:
                # Unrecognized data; just printing
                print(imsg)

    def magic(self, send_to, msg):
        magicw = 20
        magich = 10
        abracadabra = re.compile('\d+')
        magic_parameters = abracadabra.findall(msg)
        if len(magic_parameters) > 0:
            magicw = int(magic_parameters[0])
            magicw = max(4, magicw)
            magicw = min(48, magicw)
        if len(magic_parameters) > 1:
            magich = int(magic_parameters[1])
            magich = max(4, magich)
            magich = min(24, magich)

        magic_spell = mazegen(magicw, magich, True)
        for word in magic_spell:
            self.ssend('PRIVMSG {} :{}'.format(send_to, word))

def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('-s', '--server', default='irc.freenode.org')
    parser.add_argument('-p', '--port', type=int, default=6667)
    parser.add_argument('-c', '--channel', default='#spbnet')
    parser.add_argument('-n', '--nickname', default='minotaur69')
    parser.add_argument('-i', '--identity', default='cameforyou')

    args = parser.parse_args()
    print('Bot parameters: ', vars(args))
    loop = asyncio.get_event_loop()
    bot = Bot(args, loop)
    bot.connect()
    bot.run()
    loop.close()

if __name__ == '__main__':
    main()

