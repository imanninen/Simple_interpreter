## Simple CLI interpreter
Write a CLI application that supports the following commands
* `cat /path/to/file` - prints the file content
* `lc  /path/to/file` - prints lines count
* `help` - prints available commands
* `watch /path/to/dir` - locks the directory and prints about updates in it

For simplicity, it’s supposed that paths to files are absolute.

```
$ ./my-app
> lc  /Users/ravil/file.txt 
3
> cat /Users/ravil/file.txt
Line #1 
Line #2
Line #3
> help
cat
help
lc
```

You can add any commands that might be helpful for you (i.e., `exit`). 