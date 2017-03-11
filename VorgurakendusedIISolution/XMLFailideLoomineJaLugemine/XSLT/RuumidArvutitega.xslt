<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="html" indent="yes"/>

  <xsl:template match="/">
    <html>
      <head>
        <title>Arvutiklassid</title>
      </head>
      <body>
        <h2>Arvutiklassid</h2>
        <ul>
          <table>
            <xsl:for-each select="/klassid/klass">
              <tr>
                <table border="1" style="width:100%;">
                  <tr>
                    <th colspan="3">
                      <b>Klass: </b>
                      <xsl:value-of select="number"/> - <xsl:value-of select="kasutus"/>
                    </th>
                  </tr>
                  <tr>
                    <td>
                      <table>
                        <tr>
                          <td>
                            <b>Arvutid:</b>
                          </td>
                          <td></td>
                        </tr>
                        <xsl:for-each select="arvutid/arvuti">
                          <tr>
                            <td>
                              <b>Arvuti nr.</b>
                            </td>
                            <td>
                              <xsl:value-of select="number"/>
                            </td>
                          </tr>
                          <xsl:for-each select="config">
                            <tr>
                              <td>
                                <i>
                                  <xsl:value-of select="@name"/>
                                </i>
                              </td>
                              <td>
                                <xsl:value-of select="."/>
                              </td>
                            </tr>
                          </xsl:for-each>
                        </xsl:for-each>
                      </table>
                    </td>
                  </tr>
                </table>
              </tr>
            </xsl:for-each>
          </table>
        </ul>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
