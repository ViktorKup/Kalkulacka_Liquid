from watchdog.observers import Observer
import time
from watchdog.events import FileSystemEventHandler
import os
import json
import shutil


class MyHandler(FileSystemEventHandler):
    def on_modified(self, event):
        for filename in os.listdir(desktop):
            i = 1
            if filename != 'RoztrizeneSoubory':
                nove_jmeno = filename
                jsou_soubory = os.path.isfile(kamTridit + '/' + nove_jmeno)
                while jsou_soubory:
                    i += 1
                    nove_jmeno = filename + str(i)
                    jsou_soubory = os.path.isfile(kamTridit + '/' + nove_jmeno)

                src = desktop + '/' + filename
                nove_jmeno = kamTridit + '/' + nove_jmeno
                os.rename(src, nove_jmeno)


desktop = '/Users/Viktor Spliff/Desktop'
kamTridit = '/Users/Viktor Spliff/Desktop/RoztrizeneSoubory'
event_handler = MyHandler()
observer = Observer()
observer.schedule(event_handler, desktop, recursive=True)
observer.start()

try:
    while True:
        time.sleep(10)
except KeyboardInterrupt:
    observer.stop()
observer.join()