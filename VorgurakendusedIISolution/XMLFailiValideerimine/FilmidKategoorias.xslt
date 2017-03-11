<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
      <html>
        <head>
          <title>Filmide nimed ja näitlejad</title>
        </head>
        <body>
          <h2>Žanrid</h2>
          <ul>
            <xsl:for-each select="/Movies/Genres/Genre">
              <xsl:variable name="mGenre" select="."></xsl:variable>
              <li>
                <xsl:value-of select="."/>
              </li>

              <ul>
                <xsl:for-each select="/Movies/Movie[Genres/Genre = $mGenre]">  <!--If statment [] -->
                  <li>
                    <xsl:value-of select="@Name"/>
                      -
                      <xsl:value-of select="@Year"/>
                  </li>
                  <li>
                    <img src="{ImageUrl/.}" ></img>
                  </li>
                  <ul>
                    <xsl:for-each select="StarActors/Actor">
                      <li>
                        <xsl:value-of select="." />
                      </li>
                    </xsl:for-each>
                  </ul>
                </xsl:for-each>
              </ul>
            </xsl:for-each>
          </ul>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>
