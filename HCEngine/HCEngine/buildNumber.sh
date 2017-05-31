#!/bin/sh
out=$1
api="0"
rev=`git rev-list --count HEAD`
echo "namespace HCEngine" > $out
echo "{" >> $out
echo "    class Versionning" >> $out
echo "    {" >> $out
echo "        public const string Value = \"$api.$rev.*\";" >> $out
echo "    }" >> $out
echo "}" >> $out