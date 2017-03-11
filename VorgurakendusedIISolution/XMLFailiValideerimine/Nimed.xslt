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
              <li>
                <xsl:value-of select="."/>
              </li>
            </xsl:for-each>
          </ul>

          <h2>Kõik filmid</h2>
          <ul>
            <xsl:for-each select="/Movies/Movie">
              <li>
                <xsl:value-of select="@Name"/>
              </li>
              <!--Kuvada näitlejad, kes filmis osalesid-->
              <ul>
                <xsl:for-each select="StarActors/Actor">
                  <li>
                    <xsl:value-of select="." /> <!-- "." Valib praeguse elemendi-->
                  </li>
                </xsl:for-each>
              </ul>
            </xsl:for-each>
          </ul>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>
