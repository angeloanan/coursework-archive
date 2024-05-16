#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>
#include <unistd.h>

char buffer[10000];
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

// Thread function - Writer thread
void *writerThreadFn() {
  // At the soonest, acquire mutex
  pthread_mutex_lock(&mutex);

  // Acquire data from user
  printf("Input data: ");
  scanf("%[^\n]", buffer);
  getchar(); // Clears stdin buffer
  printf("\n");

  // Unlock mutex
  pthread_mutex_unlock(&mutex);
  // Exit thread
  pthread_exit(0);
}

// Thread function - Reader thread
void *readerThreadFn() {
  // Acquire mutex
  // NOOP - Blocks until child thread releases mutex
  pthread_mutex_lock(&mutex);

  printf("Hello from reader thread! Writer thread wrote the following:\n");
  printf("%s\n", buffer);
  
  // Unlock the mutex
  pthread_mutex_unlock(&mutex);

}

// Main function - Reader thread
int main(void) {
  pthread_t writerThreadHandle;
  pthread_t readerThreadHandle;
  
  // Spawn a thread
  pthread_create(&writerThreadHandle, NULL, writerThreadFn, NULL);
  pthread_create(&readerThreadHandle, NULL, readerThreadFn, NULL);
  
  // Technically can just return 0 or exit()
  // Calling this will ensure child thread exists before main process exists
  pthread_exit(NULL);
}