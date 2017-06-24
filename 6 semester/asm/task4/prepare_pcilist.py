#!/bin/python3

import csv
from collections import defaultdict, Counter

#f_pcilist = 'pcilist.csv'
f_pcilist = 'PCI.txt'
f_pcilist_clean = 'pcilist_clean.csv'
f_names_txt = 'names.txt'
f_names = 'names'
f_vendors = 'vendors'
f_devices = 'devices'

def to_word(h, change_endian=True):
    s = '{:04X}'.format(h)
    if change_endian:
        s = s[2:]+s[:2]  # change endianness
    return s

def to_dword(h, change_endian=True):
    s2 = to_word(h >> 16, change_endian)
    s1 = to_word(h & 0xffff, change_endian)
    return s1 + s2

def validate(hex_str):
    try:
        h = int(hex_str.strip(), 16)
        return to_word(h, False)
    except:
        return ''

virtual_box = ['0x80EE', '0xCAFE', 'VirtualBox mmio device']
def run():
    #fout_names_txt = open(f_names_txt, 'w')
    fout_names = open(f_names, 'w+b')
    fout_clean = open(f_pcilist_clean, 'w')
    fin = open(f_pcilist)
    pci_writer = csv.writer(fout_clean, quoting=csv.QUOTE_MINIMAL)
    reader = csv.reader(fin)

    rows = []
    bad_rows = 0
    for true_irow, row in enumerate(reader):
        vendorid = validate(row[0])
        deviceid = validate(row[1])
        correct_len = 4
        if len(vendorid) == correct_len and len(deviceid) == correct_len:
            rrow = ['0x'+vendorid, '0x'+deviceid] + row[2:]
            rows.append(rrow)
        else:
            bad_rows += 1
            print(true_irow, row)

    # just do argsort together with sort
    indices, rows = zip(*list(sorted(enumerate(rows), key=lambda x: x[1][0])))

    positions = dict()
    for irow, row in enumerate(rows):
        vendorid = row[0][2:]
        if vendorid not in positions:  # new vendor
            positions[vendorid] = [irow, irow+1]
        else:
            positions[vendorid][1] += 1

    length_offset = 0
    offsets = []
    with open(f_vendors, 'w+b') as f:
        for vendorid in sorted(positions):
            a, b = positions[vendorid]
            print(vendorid, a, b)
            vendorid = vendorid[2:] + vendorid[:2]
            hex_string = ' '.join((vendorid, to_word(a), to_word(b)))
            f.write(bytes.fromhex(hex_string))  # ascii spaces are ignored

            # sort by deviceid
            for row in sorted(rows[a:b], key=lambda x: x[1]):
                deviceid = row[1][2:]

                # writing in the clean format (only names)
                clear_names = map(lambda x: x.strip(), row[2:])
                clear_row = ','.join(clear_names)+'\n'
                clear_row = ''.join([i if ord(i) < 128 else '_' for i in clear_row])
                fout_names.write(bytes(clear_row, encoding='ascii'))
                #fout_names_txt.write(clear_row)

                # saving char offsets
                old_lo = length_offset
                length_offset += len(clear_row)
                offsets.append([deviceid, old_lo, length_offset])

    with open(f_devices, 'w+b') as f:
        for deviceid, a, b in offsets:
            print(deviceid, a, b)
            deviceid = deviceid[2:] + deviceid[:2]
            hex_string = ' '.join((deviceid, to_dword(a), to_dword(b)))
            f.write(bytes.fromhex(hex_string))  # ascii spaces are ignored

    print('Total bad rows:', bad_rows)
    print('Total vendors:', len(positions))

    pci_writer.writerows(rows)
    fout_clean.close()
    fout_names.close()
    #fout_names_txt.close()
    fin.close()

run()
