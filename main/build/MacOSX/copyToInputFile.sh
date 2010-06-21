#!/bin/sh
# Copies file.blah to file.blah.in

INFILE="$@"

if ! test -e "${INFILE}"; then
	echo "${INFILE}: No such file or directory."
	exit 1
fi

cp "${INFILE}" "${INFILE}.in"
