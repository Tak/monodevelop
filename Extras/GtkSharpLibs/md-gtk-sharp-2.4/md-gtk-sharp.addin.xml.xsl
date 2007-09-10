<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" indent="yes" />
<xsl:template match="/">
<Addin
       namespace   = "MonoDevelop"
       author      = "Lluis Sanchez"
       copyright   = "GPL"
       url         = "http://www.monodevelop.com"
       category    = "GTK">
       
    <xsl:attribute name="id">GtkCore.GtkSharp.<xsl:value-of select="/files/targetversion"/></xsl:attribute>
    <xsl:attribute name="name">GTK# <xsl:value-of select="/files/targetversion"/> Compilation Support</xsl:attribute>
    <xsl:attribute name="version"><xsl:value-of select="/files/gtkversion"/></xsl:attribute>
    <xsl:attribute name="description">Allows building applications which target GTK# <xsl:value-of select="/files/targetversion"/></xsl:attribute>

	<Runtime>
		<xsl:for-each select="/files/config|/files/dll">
			<xsl:element name="Import"><xsl:attribute name="file"><xsl:value-of select="." /></xsl:attribute></xsl:element>
		</xsl:for-each>
	</Runtime>
	
	<Dependencies>
		<Addin id="Core" version="0.14.0"/>
		<Addin id="GtkCore" version="0.14.0"/>
	</Dependencies>
	
	<Extension path = "/MonoDevelop/Core/SupportPackages">
		<Package id="art-sharp-2.0" gacRoot="true">
		    <xsl:attribute name="version"><xsl:value-of select="/files/gtkversion"/></xsl:attribute>
			<xsl:for-each select="/files/dll[contains(.,'/art-sharp')]">
				<xsl:element name="Assembly"><xsl:attribute name="file"><xsl:value-of select="." /></xsl:attribute></xsl:element>
			</xsl:for-each>
		</Package>
		<Package id="gtk-sharp-2.0" gacRoot="true">
		    <xsl:attribute name="version"><xsl:value-of select="/files/gtkversion"/></xsl:attribute>
			<xsl:for-each select="/files/dll[contains(.,'/atk-sharp') or contains(.,'/pango-sharp') or contains(.,'/gdk-sharp') or contains(.,'/gtk-sharp')]">
				<xsl:element name="Assembly"><xsl:attribute name="file"><xsl:value-of select="." /></xsl:attribute></xsl:element>
			</xsl:for-each>
		</Package>
		<Package id="vte-sharp-2.0" gacRoot="true">
		    <xsl:attribute name="version"><xsl:value-of select="/files/gtkversion"/></xsl:attribute>
			<xsl:for-each select="/files/dll[contains(.,'/vte-sharp')]">
				<xsl:element name="Assembly"><xsl:attribute name="file"><xsl:value-of select="." /></xsl:attribute></xsl:element>
			</xsl:for-each>
		</Package>
		<Package id="glib-sharp-2.0" gacRoot="true">
		    <xsl:attribute name="version"><xsl:value-of select="/files/gtkversion"/></xsl:attribute>
			<xsl:for-each select="/files/dll[contains(.,'/glib-sharp')]">
				<xsl:element name="Assembly"><xsl:attribute name="file"><xsl:value-of select="." /></xsl:attribute></xsl:element>
			</xsl:for-each>
		</Package>
		<Package id="rsvg-sharp-2.0" gacRoot="true">
		    <xsl:attribute name="version"><xsl:value-of select="/files/gtkversion"/></xsl:attribute>
			<xsl:for-each select="/files/dll[contains(.,'/rsvg-sharp')]">
				<xsl:element name="Assembly"><xsl:attribute name="file"><xsl:value-of select="." /></xsl:attribute></xsl:element>
			</xsl:for-each>
		</Package>
		<Package id="gtk-dotnet-2.0" gacRoot="true">
		    <xsl:attribute name="version"><xsl:value-of select="/files/gtkversion"/></xsl:attribute>
			<xsl:for-each select="/files/dll[contains(.,'/gtk-dotnet')]">
				<xsl:element name="Assembly"><xsl:attribute name="file"><xsl:value-of select="." /></xsl:attribute></xsl:element>
			</xsl:for-each>
		</Package>
		<Package id="gconf-sharp-2.0" gacRoot="true">
		    <xsl:attribute name="version"><xsl:value-of select="/files/gtkversion"/></xsl:attribute>
			<xsl:for-each select="/files/dll[contains(.,'/gconf-sharp')]">
				<xsl:element name="Assembly"><xsl:attribute name="file"><xsl:value-of select="." /></xsl:attribute></xsl:element>
			</xsl:for-each>
		</Package>
		<Package id="glade-sharp-2.0" gacRoot="true">
		    <xsl:attribute name="version"><xsl:value-of select="/files/gtkversion"/></xsl:attribute>
			<xsl:for-each select="/files/dll[contains(.,'/glade-sharp')]">
				<xsl:element name="Assembly"><xsl:attribute name="file"><xsl:value-of select="." /></xsl:attribute></xsl:element>
			</xsl:for-each>
		</Package>
		<Package id="gnome-sharp-2.0" gacRoot="true">
		    <xsl:attribute name="version"><xsl:value-of select="/files/gtkversion"/></xsl:attribute>
			<xsl:for-each select="/files/dll[contains(.,'/gnome-sharp')]">
				<xsl:element name="Assembly"><xsl:attribute name="file"><xsl:value-of select="." /></xsl:attribute></xsl:element>
			</xsl:for-each>
		</Package>
		<Package id="gnome-vfs-sharp-2.0" gacRoot="true">
		    <xsl:attribute name="version"><xsl:value-of select="/files/gtkversion"/></xsl:attribute>
			<xsl:for-each select="/files/dll[contains(.,'/gnome-vfs-sharp')]">
				<xsl:element name="Assembly"><xsl:attribute name="file"><xsl:value-of select="." /></xsl:attribute></xsl:element>
			</xsl:for-each>
		</Package>
		<Package id="gtkhtml-sharp-2.0" gacRoot="true">
		    <xsl:attribute name="version"><xsl:value-of select="/files/gtkversion"/></xsl:attribute>
			<xsl:for-each select="/files/dll[contains(.,'/gtkhtml-sharp')]">
				<xsl:element name="Assembly"><xsl:attribute name="file"><xsl:value-of select="." /></xsl:attribute></xsl:element>
			</xsl:for-each>
		</Package>
	</Extension>
</Addin>
</xsl:template>
</xsl:stylesheet>
