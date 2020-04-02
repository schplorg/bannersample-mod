#!/bin/bash
. config.sh
echo "delete $DIST ?"
read -p "Press enter to continue"
rm -rf "$DIST"