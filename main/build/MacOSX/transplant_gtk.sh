#!/bin/sh
# Copy necessary gtk+ and gtk# items for bundling
# $1 is the source directory 
# $2 is the destination directory

if ! test -x "$1"
then
	echo "Unable to copy from source directory $1"
	exit 1
fi

if ! test -x "$2"
then
	echo "Unable to copy from source directory $2"
	exit 2
fi

things="GNU.Gettext.dll gettext gio glib-2.0 gtk-2.0 gtk-sharp-2.0 libasprintf.0.0.0.dylib libasprintf.0.dylib libasprintf.a libasprintf.dylib libasprintf.la libatk-1.0.0.2809.1.dylib libatk-1.0.0.dylib libatk-1.0.dylib libatk-1.0.la libatksharpglue-2.a libatksharpglue-2.la libatksharpglue-2.so libcairo.2.dylib libcairo.dylib libcairo.la libcharset.1.dylib libcharset.a libcharset.dylib libcharset.la libexpat.1.5.2.dylib libexpat.1.dylib libexpat.dylib libexpat.la libfontconfig.1.dylib libfontconfig.dylib libfontconfig.la libfreetype.6.dylib libfreetype.dylib libfreetype.la libgailutil.18.dylib libgailutil.dylib libgailutil.la libgdk-quartz-2.0.0.dylib libgdk-quartz-2.0.dylib libgdk-quartz-2.0.la libgdk_pixbuf-2.0.0.dylib libgdk_pixbuf-2.0.dylib libgdk_pixbuf-2.0.la libgdksharpglue-2.a libgdksharpglue-2.la libgdksharpglue-2.so libgettextlib-0.17.dylib libgettextlib.dylib libgettextlib.la libgettextpo.0.4.0.dylib libgettextpo.0.dylib libgettextpo.a libgettextpo.dylib libgettextpo.la libgettextsrc-0.17.dylib libgettextsrc.dylib libgettextsrc.la libgio-2.0.0.dylib libgio-2.0.dylib libgio-2.0.la libglib-2.0.0.dylib libglib-2.0.dylib libglib-2.0.la libglibsharpglue-2.a libglibsharpglue-2.la libglibsharpglue-2.so libgmodule-2.0.0.dylib libgmodule-2.0.dylib libgmodule-2.0.la libgobject-2.0.0.dylib libgobject-2.0.dylib libgobject-2.0.la libgthread-2.0.0.dylib libgthread-2.0.dylib libgthread-2.0.la libgtk-quartz-2.0.0.dylib libgtk-quartz-2.0.dylib libgtk-quartz-2.0.la libgtksharpglue-2.a libgtksharpglue-2.la libgtksharpglue-2.so libiconv.2.dylib libiconv.dylib libiconv.la libintl.8.0.2.dylib libintl.8.dylib libintl.a libintl.dylib libintl.la libjpeg.7.dylib libjpeg.dylib libjpeg.la libltdl.7.dylib libltdl.dylib libltdl.la libpango-1.0.0.dylib libpango-1.0.dylib libpango-1.0.la libpangocairo-1.0.0.dylib libpangocairo-1.0.dylib libpangocairo-1.0.la libpangoft2-1.0.0.dylib libpangoft2-1.0.dylib libpangoft2-1.0.la libpangosharpglue-2.a libpangosharpglue-2.la libpangosharpglue-2.so libpangox-1.0.0.dylib libpangox-1.0.dylib libpangox-1.0.la libpixman-1.0.dylib libpixman-1.dylib libpixman-1.la libpng.3.dylib libpng.dylib libpng.la libpng12.0.dylib libpng12.dylib libpng12.la libtiff.3.dylib libtiff.dylib libtiff.la libtiffxx.3.dylib libtiffxx.dylib libtiffxx.la mono pango pkgconfig"

for thing in $things
do
	cp -R "$1/lib/$thing" "$2/lib"
done
