theme = hicolor
themedir = $(datadir)/icons/$(theme)
theme_icons = \
	apps,GNOME/monodevelop.svg \
	apps,GNOME/monodevelop-16.png \
	apps,GNOME/monodevelop-22.png \
	apps,GNOME/monodevelop-24.png \
	apps,GNOME/monodevelop-32.png \
	apps,GNOME/monodevelop-48.png

install_icon_exec = $(top_srcdir)/theme-icons/icon-theme-installer \
	-t "$(theme)" \
	-s "$(srcdir)" \
	-d "x$(DESTDIR)" \
	-b "$(themedir)" \
	-m "$(mkinstalldirs)" \
	-x "$(INSTALL_DATA)"

install-data-local:
	@-$(install_icon_exec) -i $(theme_icons)

uninstall-hook:
	@-$(install_icon_exec) -u $(theme_icons)

EXTRA_DIST = \
	$(wildcard GNOME/*.png) \
	GNOME/monodevelop.svg \
	$(wildcard Mac/png/*.png) \
	$(wildcard Mac/*.icns) \
	monodevelop-source.svg \
	icon-theme-installer

