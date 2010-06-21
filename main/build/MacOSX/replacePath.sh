#!/bin/sh
# Tiny utility for replacing a path in a text file
# Usage: replacePath.sh filename

INFILE="$@"

if ! test -e "${INFILE}"; then
	echo "${INFILE}: No such file or directory."
	exit 1
fi

# I wish OSX had rename
OUTFILE=`echo "${INFILE}" | sed 's/\.in$//'`

if test "${INFILE}" == "${OUTFILE}"; then
	echo "${INFILE} must be of the form file.in"
	exit 2
fi

DIR=$(cd "$(dirname "$0")"; pwd)
FINAL_INSTALL_DIR="$DIR/../Frameworks/Mono.framework"
MONO_FRAMEWORK_PATH="$FINAL_INSTALL_DIR/Versions/Current"

cp "${INFILE}" "${OUTFILE}"
sed -i'.orig' "s,/Library/Frameworks/Mono.framework,${FINAL_INSTALL_DIR},g" "${OUTFILE}"
