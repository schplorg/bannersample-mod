#!/bin/bash
. config.sh
echo "delete $DIST ?"
read -p "Press enter to continue"
rm -rf "$DIST"
mkdir "$DIST"
mkdir "$DIST/bin"
mkdir "$DIST/bin/Win64_Shipping_Client"
cp -rf "./$MODULE/bin/Release/0Harmony.dll" "$DIST/bin/Win64_Shipping_Client/"
cp -rf "./$MODULE/bin/Release/$MODULE.dll" "$DIST/bin/Win64_Shipping_Client/"
cp -rf "./SubModule.xml" "$DIST/"